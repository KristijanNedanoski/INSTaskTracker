<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="INSTaskTracker.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Administration</h1>
    <hr />
    <h3>Add Project:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelAddName"
                    runat="server">Name:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddProjectName" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" Text="* Project name required."
                    ControlToValidate="AddProjectName" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddStartDate"
                    runat="server">Start Date:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddProjectStartDate" runat="server" Width="180px" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" Text="* Project start date required."
                    ControlToValidate="AddProjectStartDate" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="LabelAddProjectStartDate" runat="server" Text=""></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddDescription"
                    runat="server">Description:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddProjectDescription"
                    runat="server" Width="180px" Rows="2" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" Text="* Description required."
                    ControlToValidate="AddProjectDescription" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server">Client:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:DropDownList ID="ProjectClient" runat="server"
                    SelectMethod="GetClients" AppendDataBoundItems="true"
                    DataTextField="UserName" DataValueField="Id">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server" Text="* Client user name required."
                    ControlToValidate="ProjectClient" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        <br>
        <asp:Button ID="AddProjectButton" runat="server" Text="Add Project"
            OnClick="AddProjectButton_Click" CausesValidation="true" />
        <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>

    </p>
</asp:Content>
