var app = angular.module("myApp", []);  
app.controller("myCtrl", function ($scope, $http) {
    $scope.InsertData = function () {
        debugger;
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.Name = $scope.Name;
            $scope.Employe.City = $scope.City;
            $scope.Employe.Age = $scope.Age;
            $http({
                method: "post",
                url: '/Employee/Add',
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Name = "";
                $scope.City = "";
                $scope.Age = "";
            })
        }
        else {  
            $scope.Employe = {};  
            $scope.Employe.Name = $scope.Name;  
            $scope.Employe.City = $scope.City;  
            $scope.Employe.Age = $scope.Age;  
            $scope.Employe.Id = document.getElementById("Id").value;  
            $http({  
                method: "post",  
                url: "/Employee/Update",  
                datatype: "json",  
                data: JSON.stringify($scope.Employe)  
            }).then(function(response) {  
                alert(response.data);  
                $scope.GetAllData();  
                $scope.Name = "";  
                $scope.City = "";  
                $scope.Age = "";  
                document.getElementById("btnSave").setAttribute("value", "Submit");  
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";  
                document.getElementById("spn").innerHTML = "Add New Employee";  
            })  
        }  
    }  
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "/Employee/GetEmployees"
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };

    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "/Employee/Delete",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.UpdateEmp = function (Emp) {
        document.getElementById("Id").value = Emp.Id;
        $scope.Name = Emp.Name;
        $scope.City = Emp.City;
        $scope.Age = Emp.Age;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    }
});