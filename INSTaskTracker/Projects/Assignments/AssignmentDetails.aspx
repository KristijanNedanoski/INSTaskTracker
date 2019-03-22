<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignmentDetails.aspx.cs" Inherits="INSTaskTracker.Projects.Assignments.AssignmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<<<<<<< HEAD
    <asp:FormView ID="assignmentDetail" runat="server"
        ItemType="INSTaskTracker.Models.Assignment" SelectMethod="GetAssignment"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.AssignmentName %></h1>
            </div>
            <br />
            <table>
                <br />
                <td>
                    <span>
                        <b></b><%#:Item.Description%>
                    </span>
                    <br />
                    <span>
                        <b>Developer: </b><%#:Item.UserID == null ? "Not assigned yet." : GetDeveloperName(Item.UserID)%>
                    </span>
                    <br />
                    <span>
                        <b>Start date: </b><%#:Item.StartDate.ToShortDateString()%>
                    </span>
                    <br />
                    <span>
                        <b>End date: </b><%#: Item.EndDate == null ? "in progress" : Item.EndDate.Value.ToShortDateString()%>
                    </span>
                    <br />
                    <span>
                        <b>Estimated time: </b><%#:Item.ETime%> days.
                    </span>
                    <br />

                </td>
            </table>
        </ItemTemplate>
    </asp:FormView>
=======
>>>>>>> 10dac3dd1b4789e8141fdb58353ede7de36e1cb6
</asp:Content>
