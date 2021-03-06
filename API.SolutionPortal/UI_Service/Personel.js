const GetPersons = () => {
    $.ajax({
        type: "GET",
        url: "api/Person/GetList",
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
                        companyStr += '<td><button class="btnClickPersonel btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeletePersonel btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.Company.CompanyCode + ' - ' + item.Company.CompanyDefination + '</td>';
                        companyStr += '<td>' + item.CostCenter.CostCenterCode + ' - ' + item.CostCenter.CostCenterDefination + '</td>';
                        companyStr += '<td>' + item.PersonCode + '</td>';

                        companyStr += '<td>' + item.Name + '</td>';
                        companyStr += '<td>' + item.SecondName + '</td>';
                        companyStr += '<td>' + item.Surname + '</td>';
                        companyStr += '<td>' + item.TcNo + '</td>';
                        companyStr += '<td>' + item.Department.Code + ' - ' + item.Department.Defination + '</td>';
                        companyStr += " </tr>";
                    });

                    
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Personel bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyPerson").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            alert('fail' + status.code);
        }
    });
}

const getCostCenterByCompanyId = (id) => {
    var dto = {
        CompanyId: id
    };
    $.ajax({
        type: "POST",
        url: "api/CostCenter/GetCostCenterByCompanyId",
        data: JSON.stringify(dto),// now data come in this function
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = '<option value=""></option>';
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += '<option value=' + item.Id + '>' + item.CostCenterCode + ' - ' + item.CostCenterDefination + '</option>';
                    });
                }

                $("#dropPersonCostCenter").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
        }
    });

};

const getDepartment = (id) => {
    var dto = {
        CompanyId: id
    };
    $.ajax({
        type: "GET",
        url: "api/Department/GetList",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = '<option value=""></option>';
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += '<option value=' + item.Id + '>' + item.Code+ '</option>';
                    });
                }

                $("#dropPersonDepartment").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
        }
    });

};
const GetPersonCompany = () => {
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
                        companyStr += '<option value=' + item.Id + '>' + item.CompanyCode + ' - ' + item.CompanyDefination + '</option>';
                    });
                }

                $("#dropPersonCompany").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            alert('fail' + status.code);
        }
    });
}


$(function () {
    GetPersons();
    GetPersonCompany();
    getDepartment();

    $(document).on('click', '.btnDeletePersonel', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Person/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropPersonCompany").val("");
                    $("#dropPersonCostCenter").val("");
                    $("#txtPersonelCode").val("");
                    $("#txtPersonelName12").val("");
                    $("#txtPersonelName2").val("");
                    $("#txtPersonelSurname").val("");
                    $("#txtPersonelTC").val("");
                    GetPersons();
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


    $(document).on('click', '.btnClickPersonel', function () {
        $("#dropPersonCompany").val("");
        $("#dropPersonCostCenter").val("");
        $("#txtPersonelCode").val("");
        //$("#txtPersonelName1").val("");
        $("#txtPersonelName2").val("");
        $("#txtPersonelSurname").val("");
        $("#txtPersonelTC").val("");
        $("#txtPersonelCode").val("");
        
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Person/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropCostCenterCompany").val(data.Data.CompanyId);
                    $("#txtCostCenterCode").val(data.Data.CostCenterCode);
                    $("#txtCostCenterDefination").val(data.Data.CostCenterDefination);
                    $("#dropPersonCompany").val(data.Data.Company.Id);
                    $("#dropPersonDepartment").val(data.Data.Department.Id);

                    $("#txtPersonelCode").val(data.Data.PersonCode);
                    $("#txtPersonelName12").val(data.Data.Name);
                    $("#txtPersonelName2").val(data.Data.SecondName);
                    $("#txtPersonelSurname").val(data.Data.Surname);
                    $("#txtPersonelTC").val(data.Data.TcNo);
                    $("#txtPersonelCode").val(data.Data.PersonCode);
                    
                    var dto1 = {
                        CompanyId: data.Data.Company.Id
                    };
                    $.ajax({
                        type: "POST",
                        url: "api/CostCenter/GetCostCenterByCompanyId",
                        data: JSON.stringify(dto1),// now data come in this function
                        contentType: "application/json; charset=utf-8",
                        crossDomain: true,
                        dataType: "json",
                        success: function (data1, status, jqXHR) {
    
                            if (data1.StatusCode === 200) {
                                var companyStr = '<option value=""></option>';
                                if (data1.Data.length > 0) {
                                    data1.Data.map((item) => {
                                        companyStr += '<option value="' + item.Id + '">' + item.CostCenterCode + ' - ' + item.CostCenterDefination + '</option>';
                                    });
                                }
                                $("#dropPersonCostCenter").html(companyStr);
                                $("#dropPersonCostCenter").val(data.Data.CostCenter.Id);
                            }
                        },

                        error: function (jqXHR, status) {
                        }
                    });
                 
                    //getCostCenterByCompanyId(data.Data.CompanyId);

                    $("#hdPersonClickType").val("2");
                    $("#hdPersonId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $("#dropPersonCompany").change(function () {
        var companyId = this.value;
        getCostCenterByCompanyId(companyId);
    });

    $(document).on('click', '#btnPersonSave', function () {
        var hdCompanyClickType = $("#hdPersonClickType").val();
        var hdCompanyId = $("#hdPersonId").val();

        var dropPersonCompany = $("#dropPersonCompany").val();
        var dropPersonCostCenter = $("#dropPersonCostCenter").val();
        var dropPersonDepartment = $("#dropPersonDepartment").val();
        var txtPersonelCode = $("#txtPersonelCode").val();
        var txtPersonelName1 = $("#txtPersonelName12").val();
        var txtPersonelName2 = $("#txtPersonelName2").val();
        var txtPersonelSurname = $("#txtPersonelSurname").val();
        var txtPersonelTC = $("#txtPersonelTC").val();

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
            CostCenterId: dropPersonCostCenter,
            PersonCode: txtPersonelCode,
            Name: txtPersonelName1,
            SecondName: txtPersonelName2,
            Surname: txtPersonelSurname,
            TcNo: txtPersonelTC,
            CompanyId: dropPersonCompany,
            DepartmentId: dropPersonDepartment
        };
        $("#btnPersonSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/Person/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropPersonCostCenter").html("");
                    GetPersons();
                    if (isAddOrUpdate) {
                        $("#hdPersonClickType").val("");
                        $("#hdTaxCodeId").val("");
                    }
                }

                $("#dropPersonCompany").val("");
                $("#dropPersonCostCenter").val("");
                $("#txtPersonelCode").val("");
                $("#txtPersonelName12").val("");
                $("#txtPersonelName2").val("");
                $("#txtPersonelSurname").val("");
                $("#txtPersonelTC").val("");

                $("#btnPersonSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnPersonSave").prop("disabled", false);
            }
        });

    });
});



