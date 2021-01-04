<%@ Page Title="" Language="C#" MasterPageFile="~/perdorues/perdorues.master"
    AutoEventWireup="true" CodeFile="GjitheLibrat.aspx.cs" Inherits="student_student_display_all_books" %>

<%@ MasterType VirtualPath="~/perdorues/perdorues.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">

    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <form id="shtoShporteForm" runat="server">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-header">
                    <strong class="card-title">All Books</strong>
                </div>
                <div class="card-body">

                    <asp:Repeater ID="r1" runat="server">
                        <HeaderTemplate>
                            <table class="table" id="example">
                                <thead>
                                    <tr>
                                        <th scope="col"></th>
                                        <th scope="col">Titulli</th>
                                        <th scope="col">Autori</th>
                                        <!-- <th scope="col">isbn</th>
                                    <th scope="col">available qty</th> -->
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="<%#Eval("books_image") %>" height="100" width="100" /></td>
                                <td><%#Eval("books_title") %></td>
                                <td><%#Eval("books_author_name") %></td>
                                <!-- <td><%//#Eval("books_isbn") %></td> -->
                                <td>
                                    <asp:Button ID="shtoShporteBtn" CssClass="btn btn-primary" Text="Shto ne shporte" CommandArgument='<%#Eval("books_isbn") + "," + Eval("available_qty")%>' OnClick="shtoShporteBtn_Click" runat="server"></asp:Button></td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                       </table>
                        </FooterTemplate>

                    </asp:Repeater>

                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Button ID="checkOutBtn" runat="server" Text="Shko ne checkout" />

                    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="checkOutBtn"
                        CancelControlID="Button2" BackgroundCssClass="Background">
                    </cc1:ModalPopupExtender>

                    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe style="width: 800px; height: 650px;" id="irm1" src="Checkout.aspx" runat="server"></iframe>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Close" />
                    </asp:Panel>
                </div>
            </div>
        </div>


    </form>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType": "full_numbers"
            });
        });
    </script>


</asp:Content>



