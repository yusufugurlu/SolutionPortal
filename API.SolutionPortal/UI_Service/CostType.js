const GetCostType = () => {
    $.ajax({
        type: "GET",
        url: "api/CostType/GetList",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        //dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = "";
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += "<tr>";
                        companyStr += '<td><button class="btnClickCostType btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteCostType btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.Code + '</td>';
                        companyStr += '<td>' + item.Defination + '</td>';
                        companyStr += '<td>' + item.ParentAccount + '</td>';
                        companyStr += " </tr>";
                    });
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Masraf türü bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyCostCenter").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            console.log(jqXHR);
            alert('fail' + status.code);
        }
    });
}

$(function () {
    GetCostType();

    $(document).on('click', '.btnDeleteCostType', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/CostType/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    GetCostType();
                }
                else {
                    alert(data.Message);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });


    $(document).on('click', '.btnClickCostType', function () {
        $("#txtCostTypeCode").val("");
        $("#txtCostTypeDescription").val("");
        $("#txtCostTypeMainAccount").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/CostType/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    $("#txtCostTypeCode").val(data.Data.Code);
                    $("#txtCostTypeDescription").val(data.Data.Defination);
                    $("#txtCostTypeMainAccount").val(data.Data.ParentAccount);
                    $("#hdCostCenterClickType").val("2");
                    $("#hdCostCenterId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $(document).on('click', '#btnCostTypeSave', function () {
        var hdCompanyClickType = $("#hdCostCenterClickType").val();
        var hdCompanyId = $("#hdCostCenterId").val();
        var txtCostTypeCode = $("#txtCostTypeCode").val();
        var txtCostTypeDescription = $("#txtCostTypeDescription").val();
        var txtCostTypeMainAccount = $("#txtCostTypeMainAccount").val();
        var isAddOrUpdate = false;
        try {
            if (hdCompanyClickType === "2") {
                isAddOrUpdate = true;
            }
            else {
                hdCompanyId = 0;
            }
        } catch (e) {
            hdCompanyId = 0;
        }

        var dto = {
            Id: hdCompanyId,
            Code: txtCostTypeCode,
            Defination: txtCostTypeDescription,
            ParentAccount: txtCostTypeMainAccount
        };
        $("#btnCostTypeSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/CostType/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    GetCostType();
                    if (isAddOrUpdate) {
                        $("#hdCostCenterClickType").val("");
                        $("#hdCostCenterId").val("");
                    }
                }
                $("#txtCostTypeCode").val("");
                $("#txtCostTypeDescription").val("");
                $("#txtCostTypeMainAccount").val("");
                $("#btnCostTypeSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnCostTypeSave").prop("disabled", false);
            }
        });

    });
});



