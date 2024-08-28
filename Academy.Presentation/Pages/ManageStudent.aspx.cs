using Academy.Application.Services;
using Academy.Core.Entities;
using Academy.Infrastructure.BLL;
using Academy.Infrastructure.DAL;
using System;
using System.Web.UI;

namespace Academy.Presentation.Pages
{
    public partial class ManageStudent : Page
    {
        private readonly StudentService _studentService;

        public ManageStudent()
        {
            var studentRepository = new StudentRepository(new ApplicationDbContext());
            _studentService = new StudentService(studentRepository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initialization code goes here
                GetStudentIdFromQueryString();
                string mode = GetModeFromQueryString();
                hfMode.Value = mode; // Set the mode in the hidden field

                int studentId;
                if (int.TryParse(ID.Value, out studentId))
                {
                    if (mode == "View")
                    {
                        DisableFormControls();
                    }
                    if (studentId >0)
                    {
                        LoadStudentDetails(studentId);
                    }
                }
                LitPageTitle.Text = $"{hfMode.Value} Student";
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Create a new student entity
            var student = new Student
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                DateOfBirth = DateTime.Parse(TxtDateOfBirth.Text),
                Email = TxtEmail.Text
            };
            int studentId;
            if (int.TryParse(ID.Value, out studentId))
            {
                student.Id = studentId;
                _studentService.UpdateStudent(student);
            }
            else
            {
                _studentService.AddStudent(student);
            }

            // Redirect back to the main page after saving
            Response.Redirect("Students.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to the main page without saving
            Response.Redirect("Students.aspx");
        }
        private void GetStudentIdFromQueryString()
        {
            int studentId=-1;
            if (int.TryParse(Request.QueryString["id"], out studentId))
            {
                ID.Value = studentId.ToString();
            }
            else
            {
                ID.Value= "-1";
            }
        }
        private void DisableFormControls()
        {
            TxtFirstName.Enabled = false;
            TxtLastName.Enabled = false;
            TxtDateOfBirth.Enabled = false;
            TxtEmail.Enabled = false;
            BtnSave.Visible = false;
        }
        private void LoadStudentDetails(int studentId)
        {
            var student = _studentService.GetStudentById(studentId);
            if (student != null)
            {
                TxtFirstName.Text = student.FirstName;
                TxtLastName.Text = student.LastName;
                TxtDateOfBirth.Text = student.DateOfBirth.ToString("yyyy-MM-dd"); // Ensure the date format matches your input
                TxtEmail.Text = student.Email;
            }
            else
            {
                // Handle case where student is not found
                Response.Redirect("Students.aspx");
            }
        }
        protected void CalDateOfBirth_SelectionChanged(object sender, EventArgs e)
        {
            TxtDateOfBirth.Text = CalDateOfBirth.SelectedDate.ToString("yyyy-MM-dd");
            CalDateOfBirth.Style["display"] = "none"; // Hide calendar after selection
        }

        protected void TxtDateOfBirth_TextChanged(object sender, EventArgs e)
        {
            // Optionally handle text changes
        }
        private string GetModeFromQueryString()
        {
            return Request.QueryString["mode"] ?? "Add";
        }

        // Add JavaScript for showing calendar
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string script = @"
                function showCalendar() {
                    var cal = document.getElementById('" + CalDateOfBirth.ClientID + @"');
                    cal.style.display = cal.style.display === 'none' ? 'block' : 'none';
                }

                document.addEventListener('click', function(event) {
                    var calendar = document.getElementById('" + CalDateOfBirth.ClientID + @"');
                    var textBox = document.getElementById('" + TxtDateOfBirth.ClientID + @"');
                    
                    // Check if the click is outside of the calendar and textbox
                    if (calendar.style.display === 'block' &&
                        event.target !== calendar &&
                        event.target !== textBox) {
                        calendar.style.display = 'none';
                    }
                });
            ";
            ClientScript.RegisterStartupScript(this.GetType(), "CalendarScript", script, true);
        }
    }
}