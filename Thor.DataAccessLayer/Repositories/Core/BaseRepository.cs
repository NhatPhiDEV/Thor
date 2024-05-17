using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static Thor.DataAccessLayer.Common.Enums;

namespace Thor.DataAccessLayer.Repositories.Core
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected abstract string TableName { get; }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Thực thi lệnh SQL không trả về tập kết quả (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="sql">Query</param>
        /// <param name="parameters">Query</param>
        /// <returns>Trả về số lượng hàng bị ảnh hưởng bởi việc thực thi lệnh.</returns>
        /// <exception cref="InvalidOperationException">Ngoại lệ khi khởi tạo transaction thất bại.</exception>
        protected int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            if (_unitOfWork.Transaction == null)
            {
                throw new InvalidOperationException("Transaction has not been started.");
            }

            int affectedRows;

            using (var command = new SqlCommand(sql,
                _unitOfWork.Transaction.Connection,
                _unitOfWork.Transaction))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                affectedRows = command.ExecuteNonQuery();
            }

            return affectedRows;
        }

        /// <summary>
        /// Thực thi lệnh SQL trả về danh sách đối tượng truy vấn
        /// </summary>
        /// <param name="sql">Query</param>
        /// <param name="parameters">Query</param>
        /// <returns>Trả về tập hợp các đối tượng tương ứng với đối tượng T</returns>
        /// <exception cref="InvalidOperationException">Ngoại lệ khi khởi tạo transaction thất bại.</exception>
        protected IEnumerable<T> ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            // Kiểm tra transaction
            if (_unitOfWork.Transaction == null)
            {
                throw new InvalidOperationException("Transaction has not been started.");
            }

            var list = new List<T>();

            using (var command = new SqlCommand(sql, _unitOfWork.Transaction.Connection, _unitOfWork.Transaction))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = Activator.CreateInstance<T>(); // Tạo một đối tượng mới của kiểu T
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(prop.Name))) // Kiểm tra null
                            {
                                prop.SetValue(entity, reader[prop.Name]); // Gán giá trị từ reader vào thuộc tính
                            }
                        }
                        list.Add(entity);
                    }
                }

            }

            return list;
        }

        #region CRUD 
        public void Create(T entity)
        {
            var sql = $"INSERT INTO {TableName} ({GetColumnNames()}) VALUES ({GetParameterNames()})";
            ExecuteNonQuery(sql, GetSqlParameters(entity, EQueryType.Create));
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @Id";
            ExecuteNonQuery(sql, new[] { new SqlParameter("@Id", id) });
        }

        public void Update(T entity)
        {
            var sql = $"UPDATE {TableName} SET {GetUpdateSet()} WHERE Id = @Id";
            var parameters = GetSqlParameters(entity, EQueryType.Update);
            ExecuteNonQuery(sql, parameters);
        }

        public IEnumerable<T> GetAll()
        {
            var sql = GetAllQuery();
            return ExecuteQuery(sql);
        }

        public T GetById(int id)
        {
            var sql = GetByIdQuery(id);
            return ExecuteQuery(sql).FirstOrDefault();
        }
        #endregion

        #region Private Helper Methods
        private string GetColumnNames()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id") // Loại bỏ trường Id
                .Select(p => p.Name));
        }

        private string GetParameterNames()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id") // Loại bỏ trường Id
                .Select(p => "@" + p.Name));
        }

        private string GetUpdateSet()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id") // Loại bỏ trường Id
                .Select(p => $"{p.Name} = @{p.Name}"));
        }

        private SqlParameter[] GetSqlParameters(T entity, EQueryType type)
        {
            return typeof(T).GetProperties()
                .Where(p => (type == EQueryType.Create && p.Name != "Id") || (type == EQueryType.Update)) // Loại bỏ trường Id
                .Select(p => new SqlParameter("@" + p.Name, GetPropertyValue(entity, p.Name) ?? DBNull.Value))
                .ToArray();
        }

        private object GetPropertyValue(T entity, string propertyName)
        {
            return typeof(T).GetProperty(propertyName)?.GetValue(entity, null);
        }

        protected virtual string GetAllQuery()
        {
            return $"SELECT * FROM {TableName}"; // Câu lệnh mặc định nếu không được override
        }

        protected virtual string GetByIdQuery(int Id)
        {
            return $"SELECT * FROM {TableName} WHERE Id = {Id}"; // Câu lệnh mặc định nếu không được override
        }

        #endregion
    }
}
