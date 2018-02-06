// Angular Controller
ksapp.controller('kscontroller', function ($scope, ksservice, $window) {
    // Load all staff members when the page loads
    loadEmployees();

    function loadEmployees() {
        var EmployeeRecords = ksservice.getAllEmployees();
        EmployeeRecords.then(function (d) { //Success
            $scope.Employees = d.data;
        },
        function () {
            swal("Oops...", "Error occured while loading", "error"); //Fail
        });
    }

    // Save Form data
    $scope.save = function () {
        //debugger;
        var Employee = {
            UserId: $scope.UserId,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Position: $scope.Position,
            Department: $scope.Department,
            //DateHired: $scope.DateHired
        };
        var saveemployees = ksservice.save(Employee);
        saveemployees.then(function (d) {
            $scope.UserId = d.data.UserId;
            $scope.reloadPage = function () { window.location.reload(); }
            loadEmployees();

            //swal("Staff inserted successfully");
        },
        function () {
            swal("Oops...", "Error occured while saving", "error");
        });
    }
});