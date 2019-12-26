var empApp = angular.module('EmpApp', []);

empApp.controller('EmpController', function ($scope,$http) {

    $scope.Init = function () {
        $http({
            url: '/Home/Init',
            method: 'post'
        }).then(function successCallback(response) {
            debugger;
            $scope._empObj = response.data._empObj;
            $scope.EmployeeList = response.data.EmployeeList;
            $scope.CountryList = response.data.CountryList;
            $scope.StateList = response.data.StateList;
            $scope.GenderList = response.data.GenderList;
            $scope.MaritalStatusList = response.data.MaritalStatusList;
            $scope.DepartmentList = response.data.DepartmentList;
            $scope.SearchText = undefined;

        }, function errorCallback(response) {

        });
    }

    $scope.FindById = function (Id) {
        debugger;
        $http({
            url: '/Home/FindById',
            method: 'post',
            data: { Id:Id}
        }).then(function successCallback(response) {
            debugger;
            $scope._empObj = response.data;
            $scope._empObj.GenderId = $scope._empObj.GenderId.toString();
            $scope._empObj.MaritalStatusId = $scope._empObj.MaritalStatusId.toString();
            $scope._empObj.DeptId = $scope._empObj.DeptId.toString();
            $scope._empObj.CountryId = $scope._empObj.CountryId.toString();
            $scope._empObj.StateId = $scope._empObj.StateId.toString();
            $scope.ActivaTab('home');
            $scope.Validate();
        }, function errorCallback(response) {

        });
    }

    $scope.Save = function () {
        debugger;
        var isValid = false;
        isValid = $scope.Validate();
        if (isValid) {
            $http({
                url: '/Home/Save',
                method: 'post',
                data: { pEmpObj: $scope._empObj }
            }).then(function successCallback(response) {
                debugger;
                $scope.ActivaTab('home');
                $scope.Init();
                $scope.ClearClass();
            }, function errorCallback(response) {

            });
        }       
    }

    $scope.Delete = function (Id) {
        $http({
            url: '/Home/Delete',
            method: 'post',
            data: { Id: Id }
        }).then(function successCallback(response) {
            debugger;
            $scope.Init();
        }, function errorCallback(response) {

        });
    }

    $scope.ActivaTab = function (tab) {
        $('.nav-tabs a[href="#' + tab + '"]').tab('show');
    };

    $scope.EmployeeSearch = function () {
        $http({
            url: '/Home/SearchEmployee',
            method: 'post',
            data: { SearchText: $scope.SearchText }
        }).then(function successCallback(response) {
            $scope.EmployeeList = response.data;
        }, function errorCallback(response) {

        });
    };

    $scope.Validate = function () {
        debugger;
        var isValid = false;
        if ($scope._empObj.FirstName == null || $scope._empObj.FirstName == undefined || $scope._empObj.FirstName == '') {
            $("#FirstName").removeClass("is-valid");
            $("#FirstName").addClass("is-invalid");
           
            return false;
        } else {
            $("#FirstName").removeClass("is-invalid");
            $("#FirstName").addClass("is-valid");
         
            isValid = true;
        }
        if ($scope._empObj.MiddleName == null || $scope._empObj.MiddleName == undefined || $scope._empObj.MiddleName == '') {
            $("#MiddleName").removeClass("is-valid");
            $("#MiddleName").addClass("is-invalid");
          
            return false;
        } else {
            $("#MiddleName").removeClass("is-invalid");
            $("#MiddleName").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.LastName == null || $scope._empObj.LastName == undefined || $scope._empObj.LastName == '') {
            $("#LastName").removeClass("is-valid");
            $("#LastName").addClass("is-invalid");
          
            return false;
        } else {
            $("#LastName").removeClass("is-invalid");
            $("#LastName").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.Age == null || $scope._empObj.Age == undefined || $scope._empObj.Age == '') {
            $("#Age").removeClass("is-valid");
            $("#Age").addClass("is-invalid");
           
            return false;
        } else {
            var ageRegex = /^[1-9][0-9]?$|^100$/;
            var isValidAge = ageRegex.test($scope._empObj.Age);
            if (isValidAge) {
                $("#Age").removeClass("is-invalid");
                $("#Age").addClass("is-valid");
                isValid = true;
            } else {
                $("#Age").removeClass("is-valid");
                $("#Age").addClass("is-invalid");
             
                return false;
            }
        }
        if ($scope._empObj.GenderId == null || $scope._empObj.GenderId == undefined || $scope._empObj.GenderId == '') {
            $("#GenderId").removeClass("is-valid");
            $("#GenderId").addClass("is-invalid");
         
            return false;
        } else {
            $("#GenderId").removeClass("is-invalid");
            $("#GenderId").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.MaritalStatusId == null || $scope._empObj.MaritalStatusId == undefined || $scope._empObj.MaritalStatusId == '') {
            $("#MaritalStatusId").removeClass("is-valid");
            $("#MaritalStatusId").addClass("is-invalid");
          
            return false;
        } else {
            $("#MaritalStatusId").removeClass("is-invalid");
            $("#MaritalStatusId").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.DeptId == null || $scope._empObj.DeptId == undefined || $scope._empObj.DeptId == '') {
            $("#DeptId").removeClass("is-valid");
            $("#DeptId").addClass("is-invalid");
        
            return false;
        } else {
            $("#DeptId").removeClass("is-invalid");
            $("#DeptId").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.Salary == null || $scope._empObj.FirstName == Salary || $scope._empObj.Salary == '') {
            $("#Salary").removeClass("is-valid");
            $("#Salary").addClass("is-invalid");
       
            return false;
        } else {
            var salaryRegex = /^[0-9]*$/;
            var isValidSalary = salaryRegex.test($scope._empObj.Salary);
            if (isValidSalary) {
                $("#Salary").removeClass("is-invalid");
                $("#Salary").addClass("is-valid");
                isValid = true;
            } else {
                $("#Salary").removeClass("is-valid");
                $("#Salary").addClass("is-invalid");
             
                return false;
            }
        }
        if ($scope._empObj.Email == null || $scope._empObj.Email == Salary || $scope._empObj.Email == '') {
            $("#Email").removeClass("is-valid");
            $("#Email").addClass("is-invalid");
            return false;
        } else {

            var emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            var isValidEmail = emailRegex.test($scope._empObj.Email);
            if (isValidEmail) {
                $("#Email").removeClass("is-invalid");
                $("#Email").addClass("is-valid");
                isValid = true;
            } else {
                $("#Email").removeClass("is-valid");
                $("#Email").addClass("is-invalid");             
                return false;
            }
           
        }
       
        if ($scope._empObj.MobileNo == null || $scope._empObj.MobileNo == Salary || $scope._empObj.MobileNo == '') {
            $("#MobileNo").removeClass("is-valid");
            $("#MobileNo").addClass("is-invalid");
            return false;
        } else {
            var mobileRegex = /^([0|\+[0-9]{1,5})?([7-9][0-9]{9})$/;
            var isValidMobile = mobileRegex.test($scope._empObj.MobileNo);
            if (isValidMobile) {
                $("#MobileNo").removeClass("is-invalid");
                $("#MobileNo").addClass("is-valid");
               
                isValid = true;
            } else {
                $("#MobileNo").removeClass("is-valid");
                $("#MobileNo").addClass("is-invalid");               
                return false;
            }
        }
        if ($scope._empObj.Address == null || $scope._empObj.Address == Salary || $scope._empObj.Address == '') {
            $("#Address").removeClass("is-valid");
            $("#Address").addClass("is-invalid");
            $scope.ActivaTab('profile');
            return false;
        } else {
            $("#Address").removeClass("is-invalid");
            $("#Address").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.CountryId == null || $scope._empObj.CountryId == Salary || $scope._empObj.CountryId == '') {
            $("#CountryId").removeClass("is-valid");
            $("#CountryId").addClass("is-invalid");
            $scope.ActivaTab('profile');
            return false;
        } else {
            $("#CountryId").removeClass("is-invalid");
            $("#CountryId").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.StateId == null || $scope._empObj.StateId == Salary || $scope._empObj.StateId == '') {
            $("#StateId").removeClass("is-valid");
            $("#StateId").addClass("is-invalid");
            $scope.ActivaTab('profile');
            return false;
        } else {
            $("#StateId").removeClass("is-invalid");
            $("#StateId").addClass("is-valid");
            isValid = true;
        }
        if ($scope._empObj.Pincode == null || $scope._empObj.Pincode == Salary || $scope._empObj.Pincode == '') {
            $("#Pincode").removeClass("is-valid");
            $("#Pincode").addClass("is-invalid");
            $scope.ActivaTab('profile');
            return false;
        } else {
            var pincodeRegex = /^[0-9]*$/;
            var isValidPincode = pincodeRegex.test($scope._empObj.Pincode);
            if (isValidPincode) {
                $("#Pincode").removeClass("is-invalid");
                $("#Pincode").addClass("is-valid");
                isValid = true;
            } else {
                $("#Pincode").removeClass("is-valid");
                $("#Pincode").addClass("is-invalid");
                $scope.ActivaTab('profile');
                return false;
            }
        }
        return isValid;
    }

    $scope.ClearClass = function () {

        $("#FirstName").removeClass("is-valid");

        $("#FirstName").removeClass("is-invalid");

        $("#MiddleName").removeClass("is-valid");

        $("#MiddleName").removeClass("is-invalid");

        $("#LastName").removeClass("is-valid");

        $("#LastName").removeClass("is-invalid");

        $("#Age").removeClass("is-valid");

        $("#Age").removeClass("is-invalid");

        $("#GenderId").removeClass("is-valid");

        $("#GenderId").removeClass("is-invalid");

        $("#MaritalStatusId").removeClass("is-valid");

        $("#MaritalStatusId").removeClass("is-invalid");

        $("#DeptId").removeClass("is-valid");

        $("#DeptId").removeClass("is-invalid");

        $("#Salary").removeClass("is-valid");

        $("#Salary").removeClass("is-invalid");

        $("#Email").removeClass("is-valid");

        $("#Email").removeClass("is-invalid");

        $("#MobileNo").removeClass("is-valid");

        $("#MobileNo").removeClass("is-invalid");

        $("#Address").removeClass("is-valid");

        $("#Address").removeClass("is-invalid");

        $("#CountryId").removeClass("is-valid");

        $("#CountryId").removeClass("is-invalid");

        $("#StateId").removeClass("is-valid");

        $("#StateId").removeClass("is-invalid");

        $("#Pincode").removeClass("is-valid");

        $("#Pincode").removeClass("is-invalid");

    }
});