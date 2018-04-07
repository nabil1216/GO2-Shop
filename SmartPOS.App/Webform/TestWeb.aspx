<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWeb.aspx.cs" Inherits="SmartPOS.App.Webform.TestWeb" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
    <title>SPACE-SMART POS</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
   
<body>
    <form id="form1" runat="server">
        <label >SPACE-SMART POS</label>
    <div>
        <div class="card">
            <div class="card-block">
                <hr />
                <div class="form-group">
                   <div class="col-md-2"> Name</div>
                    <div class="col-md-6">
                        <input class = "form-control form-control-line" type="text" id="txtName" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-12">
                        <input type="submit" class="btn btn-success" value="Save" name="Brnad" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
