<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="EmployeeFeedBack.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager runat="server" ID="script1"/>--%>
    <link href="Content/Styles/dataGridView.css" rel="stylesheet" />
    <link href="Content/Styles/home.css" rel="stylesheet" />
     <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure ? Yoy won't be able to go back ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <div class="container">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <h1 class="text-center">Payroll complaints</h1>
                <div class="mb-3" id="dropEmpname">
                    <div class="d-grid gap-2">
                        <asp:Button ID="add" runat="server" Height="40px" Text="Add request" Width="1457px" class="btn"/>
                    </div>
                </div>
                <asp:GridView ID="payrollView" PageSize="5" OnRowCommand="payrollView_RowCommand" OnPageIndexChanging="OnPageIndexChanging" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" Width="1251px" Height="16px" CellPadding="3">
                 <Columns>
                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Button Text="Edit" runat="server" CommandName="Edittt" CommandArgument="<%# Container.DataItemIndex %>" class="btn"/>
                        </ItemTemplate>
        <%--                <ItemTemplate>
                            <asp:ImageButton ID="imgId" ImageUrl="Content/resources/images/editing.png" runat="server" OnClick="GetId" />
                        </ItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" class="btn"/>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
<%--                    <asp:BoundField DataField="EmpCode" HeaderText="ID" />--%>
                </Columns>

                <HeaderStyle CssClass="header"></HeaderStyle>

                <PagerStyle CssClass="pager"></PagerStyle>

                <RowStyle CssClass="rows"></RowStyle>

                </asp:GridView>
                <div class="row pt-3">
                    <div class="col-sm-5" id="txtname">
                        <asp:TextBox ID="txtId" runat="server" class="form-control bg-light income" placeholder="Emp code" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 mt-sm-0 mt-3" id="dropEmpname">
                        <div class="">
                            <asp:Button ID="delete" runat="server" Height="40px" Text="Delete request" Width="1457px" class="btn" OnClientClick="Confirm()"/>
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblmsg" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
