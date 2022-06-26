const GetCostCenter = () => {
    $.ajax({
        type: "GET",
        url: "api/CostCenter/GetList",
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
                        companyStr += '<td><button class="btnClickCostCenter btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteCostCenter btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.CompanyName + '</td>';
                        companyStr += '<td>' + item.CostCenterCode + '</td>';
                        companyStr += '<td>' + item.CostCenterDefination + '</td>';
                        companyStr += " </tr>";
                    });
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Vergi Kodu bulunamadı.</td>';
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

const GetCostCenterCompany = () => {
    $.ajax({
        type: "GET",
        url: "api/Company/GetList",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        //dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = '<option value=""></option>';
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += '<option value='+item.Id+'>'+item.CompanyCode+'</option>';
                    });
                }

                $("#dropCostCenterCompany").html(companyStr);
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
    GetCostCenter();
    GetCostCenterCompany();

    $(document).on('click', '.btnDeleteCostCenter', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/CostCenter/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    GetCostCenter();
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


    $(document).on('click', '.btnClickCostCenter', function () {
        $("#dropCostCenterCompany").val("");
        $("#txtCostCenterCode").val("");
        $("#txtCostCenterDefination").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/CostCenter/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    $("#dropCostCenterCompany").val(data.Data.CompanyId);
                    $("#txtCostCenterCode").val(data.Data.CostCenterCode);
                    $("#txtCostCenterDefination").val(data.Data.CostCenterDefination);

                    $("#hdCostCenterClickType").val("2");
                    $("#hdCostCentereId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $(document).on('click', '#btnCostCenterSave', function () {
        var hdCompanyClickType = $("#hdCostCenterClickType").val();
        var hdCompanyId = $("#hdCostCentereId").val();
        var dropCostCenterCompany = $("#dropCostCenterCompany").val();
        var txtCostCenterCode = $("#txtCostCenterCode").val();
        var txtCostCenterDefination = $("#txtCostCenterDefination").val();
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
            CostCenterCode: txtCostCenterCode,
            CostCenterDefination: txtCostCenterDefination,
            CompanyId: dropCostCenterCompany
        };
        $("#btnCostCenterSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/CostCenter/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    GetCostCenter();
                    if (isAddOrUpdate) {
                        $("#hdTaxCodeClickType").val("");
                        $("#hdTaxCodeId").val("");
                    }
                }

                $("#dropCostCenterCompany").val("");
                $("#txtCostCenterCode").val("");
                $("#txtCostCenterDefination").val("");

                $("#btnCostCenterSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnCostCenterSave").prop("disabled", false);
            }
        });

    });
});



