const GetCostDepartment = () => {
    $.ajax({
        type: "GET",
        url: "api/Department/GetList",
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
                        companyStr += '<td><button class="btnClickDepartment btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteDepartment btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.Code + '</td>';
                        companyStr += '<td>' + item.Defination + '</td>';
                        companyStr += '<td>' + item.PersonelCode + '</td>';
                        companyStr += " </tr>";
                    });
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Departman bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyDepartment").html(companyStr);
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
    GetCostDepartment();

    $(document).on('click', '.btnDeleteDepartment', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Department/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#txtDepartmentCode").val("");
                    $("#txtDepartmentDefination").val("");
                    $("#txtPersonelCode").val("");
                    GetCostDepartment();
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


    $(document).on('click', '.btnClickDepartment', function () {
        $("#txtDepartmentCode").val("");
        $("#txtDepartmentDefination").val("");
        $("#txtPersonelCode").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Department/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    $("#txtDepartmentCode").val(data.Data.Code);
                    $("#txtDepartmentDefination").val(data.Data.Defination);
                    $("#txtPersonelCode").val(data.Data.PersonelCode);

                    $("#hdDepartmentClickType").val("2");
                    $("#hdDepartmentId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $(document).on('click', '#btnDepartmentSave', function () {
        var hdCompanyClickType = $("#hdDepartmentClickType").val();
        var hdCompanyId = $("#hdDepartmentId").val();
        var txtDepartmentCode = $("#txtDepartmentCode").val();
        var txtDepartmentDefination = $("#txtDepartmentDefination").val();
        var txtPersonelCode = $("#txtPersonelCode").val();
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
            Code: txtDepartmentCode,
            Defination: txtDepartmentDefination,
            PersonelCode: txtPersonelCode
        };
        $("#btnDepartmentSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/Department/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    GetCostDepartment();
                    if (isAddOrUpdate) {
                        $("#hdCostCenterClickType").val("");
                        $("#hdCostCenterId").val("");
                    }
                }
                $("#txtDepartmentCode").val("");
                $("#txtDepartmentDefination").val("");
                $("#txtPersonelCode").val("");
                $("#btnDepartmentSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnDepartmentSave").prop("disabled", false);
            }
        });

    });
});



