using Thor.BusinessLogicLayer.Services.Courses;

namespace Thor.PresentationLayer.Forms
{
    public partial class CourseForm : Form
    {
        private readonly ICourseService _courseService;

        public CourseForm()
        {
            _courseService = new CourseService();
            InitializeComponent();
        }

        private void LoadCourses()
        {
            try
            {
                dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCourses.DataSource = null;
                var courses = _courseService.GetAllCourses();
                var bindingSource = new BindingSource
                {
                    DataSource = courses
                };
                dgvCourses.DataSource = bindingSource;

                tbCouseId.DataBindings.Add("Text", bindingSource, "Id");
                tbCouseName.DataBindings.Add("Text", bindingSource, "Name");
                tbCouseDescription.DataBindings.Add("Text", bindingSource, "Description");

                AddRowNumberToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}");
            }
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void AddRowNumberToDataGridView()
        {
            dgvCourses.Columns.Insert(0, new DataGridViewTextBoxColumn() // Thêm cột vào vị trí đầu tiên
            {
                HeaderText = "STT",
                Name = "STT",
                ReadOnly = true, // Không cho phép chỉnh sửa
            });

            for (int i = 0; i < dgvCourses.Rows.Count; i++)
            {
                dgvCourses.Rows[i].Cells["STT"].Value = i + 1; // Đánh số thứ tự từ 1
            }

            dgvCourses.Columns["STT"].Width = 60;
            dgvCourses.Columns["Id"].Width = 100;

        }
    }
}
