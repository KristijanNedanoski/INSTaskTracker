<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignmentList.aspx.cs" Inherits="INSTaskTracker.Projects.Assignments.AssignmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="assignmentList" runat="server"
                DataKeyNames="AssignmentID" GroupItemCount="4"
                ItemType="INSTaskTracker.Models.Assignment" SelectMethod="GetAssignments">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a
                                        href="AssignmentDetails.aspx?assignmentID=<%#:Item.AssignmentID%>">
                                        </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a
                                        href="AssignmentDetails.aspx?assignmentID=<%#:Item.AssignmentID%>">
                                        <span>
                                            <%#:Item.AssignmentName%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Start date: </b><%#:Item.StartDate.ToShortDateString()%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Estimated time: </b><%#:Item.ETime%> days.
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer"
                                        runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
