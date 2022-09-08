<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="EmployeeFeedBack.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <div class="wrapper">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="bg-white" id="upper-section">
                    <h5>Payroll complaints</h5>
                    <div class="row pt-3">
                       <div class="col-sm-4" id="dropEmpname">
                            <div id="dropdown" class="bg-light rounded border">
                                <p>Request Id</p>
                                <asp:TextBox ID="txtId" runat="server" class="form-control bg-light" Enabled="false"></asp:TextBox>
                                &nbsp;
                            </div>
                        </div>
                        <div class="col-sm-4" id="txtname">
                            <div id="dropdown" class="bg-light rounded border">
                                <p>Store Name</p>
                                <asp:DropDownList ID="DropStore" runat="server" class="bg-light">
                                    <asp:ListItem>New York, Fifth Avenue</asp:ListItem>
                                    <asp:ListItem>Dominican Republic, Santo Domingo</asp:ListItem>
                                    <asp:ListItem>New Jearsy, Eighth Avenue</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            </div>
                        </div>
                        <div class="col-sm-3 mt-sm-0 mt-3" id="dropEmpname">
                            <div id="dropdown" class="bg-light rounded border">
                                <p>Employee</p>
                                <asp:DropDownList ID="DropEmp" runat="server" class="bg-light">
                                    <asp:ListItem>Anonymous</asp:ListItem>
                                    <asp:ListItem>Ramy Campusano Volquez</asp:ListItem>
                                    <asp:ListItem>Martin Alexander</asp:ListItem>
                                    <asp:ListItem>Jose Garcia</asp:ListItem>
                                    <asp:ListItem>Junior Campusano Volquez</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mt-3 bg-white" id="middle-section">
                    <div class="d-sm-flex flex-sm-row align-items-center">
                        <h5>Income</h5>
                        <a href="#" class="ml-auto">why do we need this?<span class="px-1 fa fa-question-circle"></span></a>
                    </div>
                    <p class="pt-2 text-muted text-justify">
                        Enter your income pre-tax. If you get paid other than once in a month, sum up your income to match the
                        monthly value.
                    </p>
                    <div class="rounded">
                        &nbsp;
                        <asp:TextBox ID="txtincome" runat="server" class="form-control bg-light income"></asp:TextBox>
                         <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtincome"
                            ErrorMessage="Last store name is a required field."
                            ForeColor="Red">
                         </asp:RequiredFieldValidator>
                    </div>
                    <h6 class="pt-4">How often do you get paid?</h6>
                    <div class="row p-3">
                        <asp:RadioButtonList ID="RadioPayment_date_month" runat="server" Height="17px" RepeatDirection="Horizontal" Width="1177px">
                            <asp:ListItem>Weekly</asp:ListItem>
                            <asp:ListItem>Every Other Week</asp:ListItem>
                            <asp:ListItem>Twice a Month</asp:ListItem>
                            <asp:ListItem>Day of the Month</asp:ListItem>
                            <asp:ListItem>Weekday of the Month</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <h6 class="pt-4">Which day of the week do you normally get paid?</h6>
                    <div class="d-sm-flex justify-content-between align-items-center pt-2">
                        <asp:RadioButtonList ID="RadioPayment_date_week" runat="server" Height="17px" RepeatDirection="Horizontal" Width="1177px">
                            <asp:ListItem>Sun</asp:ListItem>
                            <asp:ListItem>Mon</asp:ListItem>
                            <asp:ListItem>Tue</asp:ListItem>
                            <asp:ListItem>Wed</asp:ListItem>
                            <asp:ListItem>Thu</asp:ListItem>
                            <asp:ListItem>Fri</asp:ListItem>
                            <asp:ListItem>Sat</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="mt-3 bg-white" id="lower-section">
                    <div class="d-sm-flex flex-sm-row align-items-center">
                        <h5>Bank Account Information</h5>
                        <a href="#" class="ml-auto">  why do we need this?<span class="px-1 fa fa-question-circle"></span></a>
                    </div>
                    <p class="pt-2 text-muted text-justify">
                        Fill in your bank account details or connect with bank account.
                    </p>
                    <div class="row">
                        <div class="col-md-5">
                            <div id="account" class="bg-light rounded border">
                                <p>Routing Number</p>
                                <asp:TextBox ID="txtrouting_number" runat="server" class="form-control bg-light" placeholder="1208828"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtrouting_number" 
                                    ErrorMessage="Enter a valid routing number"
                                    ValidationExpression="^\d+$"
                                    ForeColor="Red">
                                </asp:RegularExpressionValidator>
                                &nbsp;
                            </div>
                        </div>
                        <div class="col-md-7 mt-md-0 mt-4">
                            <div id="account" class="bg-light rounded border">
                                <p>Account Number</p>
                                <asp:TextBox ID="txtaccount_number" runat="server" class="form-control bg-light" placeholder="64525398784"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="txtaccount_number" 
                                    ErrorMessage="Enter a valid routing number"
                                    ValidationExpression="^\d+$"
                                    ForeColor="Red">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>  
                        <div class="mt-md-0 pt-4 pb-3 m-1">
                            <div class="bg-light rounded">
                                <h5 class="mb-4">Description</h5>
                                <asp:TextBox ID="txtdesc" runat="server" class="form-control bg-light textarea" placeholder="Hello, Mr ..." Height="52px"></asp:TextBox>
                                &nbsp;
                            </div>
                        </div>
                        <div class="col-md-4 mt-1">
                            <div class="d-grid gap-2">
                                <asp:Button ID="update" runat="server" Height="40px" Text="Update request" Width="1457px" class="btn"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>

</div>
</asp:Content>
