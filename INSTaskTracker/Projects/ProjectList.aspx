<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="INSTaskTracker.ProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="projectList" runat="server"
                DataKeyNames="ProjectID" GroupItemCount="4"
                ItemType="INSTaskTracker.Models.Project" SelectMethod="GetProjects">
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
                                        href="ProjectDetails.aspx?projectID=<%#:Item.ProjectID%>">
                                        </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a
                                        href="ProjectDetails.aspx?projectID=<%#:Item.ProjectID%>">
                                        <span>
                                            <%#:Item.ProjectName%>
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
                                    <span>
                                       <b>Client: </b> <%#:GetClientName(Item.UserID) %>
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
