<%@ Page Title="AddStudent" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageStudent.aspx.cs" Inherits="Academy.Presentation.Pages.ManageStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" class="container mt-4">
        <h2><asp:Literal ID="LitPageTitle" runat="server" Text="Edit Student"></asp:Literal></h2>
            
         <asp:HiddenField ID="hfMode" runat="server" />
         <asp:HiddenField ID="ID" runat="server" />
        <div class="form-group">
            <label for="TxtFirstName">First Name:</label>
            <asp:TextBox ID="TxtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TxtLastName">Last Name:</label>
            <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
             
        <div class="form-group">
            <label for="TxtDateOfBirth">Date of Birth:</label>
            <asp:TextBox ID="TxtDateOfBirth" runat="server" CssClass="form-control" 
                OnClick="showCalendar()" AutoPostBack="true"></asp:TextBox>
            <asp:Calendar ID="CalDateOfBirth" runat="server" 
                OnSelectionChanged="CalDateOfBirth_SelectionChanged" 
                CssClass="form-control" Style="display:none;" />
        </div>

        <div class="form-group">
            <label for="TxtEmail">Email:</label>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="BtnCancel_Click" />
        </div>
    </form>
</asp:Content>