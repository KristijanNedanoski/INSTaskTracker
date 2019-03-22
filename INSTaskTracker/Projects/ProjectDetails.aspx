<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="INSTaskTracker.Projects.ProjectDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:FormView ID="projectDetail" runat="server"
        ItemType="INSTaskTracker.Models.Project" SelectMethod="GetProject"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProjectName %></h1>
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
                        <b>Client: </b><%#:GetClientName(Item.UserID) %>
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
                    <span>
                        <a runat="server" id="AddTaskLink" visible="true" href="Assignments/Developer/AddAssignmentPage.aspx?projectID=<%#:Item.ProjectID%>">Add Task</a>
                    </span>
                    <br />
                    <span>
                        <a runat="server" id="MyAssignmentsLink" visible="true" href="Assignments/AssignmentList.aspx?projectID=<%#:Item.ProjectID%>&list=Mine">View your current assignments</a>
                    </span>
                    <br />
                    <span>
                        <a href="Assignments/AssignmentList.aspx?projectID=<%#:Item.ProjectID%>&list=Current">View in progress assignments</a>
                    </span>
                    <br />
                    <span>
                        <a href="Assignments/AssignmentList.aspx?projectID=<%#:Item.ProjectID%>&list=Planned">View planned assignments</a>
                    </span>
                    <br />
                    <span>
                        <a href="Assignments/AssignmentList.aspx?projectID=<%#:Item.ProjectID%>&list=Finished">View Finished assignments</a>
                    </span>
                    <br />
                    

                </td>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
