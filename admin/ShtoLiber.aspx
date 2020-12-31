<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeFile="ShtoLiber.aspx.cs" Inherits="librarian_add_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Shto liber</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">

                        

                        <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Titulli</label>
                                <asp:TextBox ID="bookstitle" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Foto</label>
                                <asp:FileUpload ID="f1" runat="server" class="form-control" required />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Autori</label>
                                <asp:TextBox ID="authorname" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">ISBN</label>
                                <asp:TextBox ID="isbn" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Sasia</label>
                                <asp:TextBox ID="qty" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Shto liber" OnClick="b1_Click" />
                            </div>

                            <div class="alert alert-success" id="msg" runat="server" style="margin-top: 10px; display: none">
                                <strong>Libri u shtua me sukses!</strong>
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

