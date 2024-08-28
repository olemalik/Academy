using Academy.Application.Services;
using Academy.Infrastructure.BLL;
using Academy.Infrastructure.DAL;
using System;
using System.Web.UI.WebControls;

namespace Academy.Presentation.Pages
{
    public partial class Students : System.Web.UI.Page
    {
        private StudentService _studentService;

        protected void Page_Load(object sender, EventArgs e)
        {

            var studentRepository = new StudentRepository(new ApplicationDbContext());
            _studentService = new StudentService(studentRepository);
            if (!IsPostBack)
            {

                BindStudentData();
            }
        }

        private void BindStudentData()
        {
            var students = _studentService.GetAllStudents();
            GridViewStudents.DataSource = students;
            GridViewStudents.DataBind();
        }
        protected void GridViewStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                // Redirect to the Edit page with the student ID.
                Response.Redirect($"ManageStudent.aspx?id={id}&mode={e.CommandName}");
            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument);
                _studentService.DeleteStudent(id);
                // Call the delete method from your data service.
                // Example:
                // studentService.DeleteStudent(id);
                // Rebind the GridView.
                BindStudentData();
            }
        }

        protected void BtnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageStudent.aspx");
        }
    }
}