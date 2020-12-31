
<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeFile="pwd_reset.aspx.cs" Inherits="librarian_pwd_reset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Reset Student Password</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">



                        <form id="fo1" runat="server">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Default password is Student123</label></br>
                               Username:<asp:TextBox ID="student_username" runat="server" class="form-control" required OnTextChanged="student_username_TextChanged"></asp:TextBox>
                              First Name:<asp:TextBox ID="student_name" runat="server" class="form-control"  ></asp:TextBox>
                            </div>


                            <div>

                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Reset" />

                            </div>


                        </form>
                    </div>
                </div>

            </div>
        </div>
        <!-- .card -->

    </div>
    <!--/.col-->

</asp:Content>

