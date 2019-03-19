<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAssignmentPage.aspx.cs" Inherits="INSTaskTracker.Projects.Assignments.Developer.AddAssignmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <h1>Administration</h1>
    <hr />
    <h3>Add Assignment:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelAddName"
                    runat="server">Assignment Name:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddAssignmentName" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" Text="* Project name required."
                    ControlToValidate="AddAssignmentName" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddEstimatedTime"
                    runat="server">Estimated Time (in days):</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddAssignmentEstimatedTime" runat="server" Width="180px" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" Text="* Estimated time required."
                    ControlToValidate="AddAssignmentEstimatedTime" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddStartDate"
                    runat="server">Start Date:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddAssignmentStartDate" runat="server" Width="180px" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" Text="* Project start date required."
                    ControlToValidate="AddAssignmentStartDate" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="LabelAddAssignmentStartDate" runat="server" Text=""></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddDescription"
                    runat="server">Description:</asp:Label></td>
            <td style="width: 1018px" class="modal-lg">
                <asp:TextBox ID="AddAssignmentDescription"
                    runat="server" Width="180px" Rows="2" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" Text="* Description required."
                    ControlToValidate="AddAssignmentDescription" SetFocusOnError="true"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        <br>
        <asp:Button ID="AddAssignmentButton" runat="server" Text="Add Assignment"
            OnClick="AddAssignmentButton_Click" CausesValidation="true" />
        <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>

    </p>
</asp:Content>
