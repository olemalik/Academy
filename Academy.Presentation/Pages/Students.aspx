<%@ Page Title="Students List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Academy.Presentation.Pages.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Student List</h2>
        <!-- Add Student Button -->
        <asp:Button ID="BtnAddStudent" runat="server" Text="Add Student" CssClass="btn btn-primary" OnClick="BtnAddStudent_Click" />

        <br /><br />

        <!-- Student List GridView -->
        <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridViewStudents_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="BtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                        <asp:Button ID="BtnView" runat="server" CommandName="View" CommandArgument='<%# Eval("Id") %>' Text="View" CssClass="btn btn-info btn-sm" />
                        <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this student?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
