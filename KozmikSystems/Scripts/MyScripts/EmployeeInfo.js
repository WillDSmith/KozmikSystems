/// <reference path="../jquery-3.3.1.min.js" />
/// <reference path="../knockout-3.4.2.js" />


(function () {
    var viewModel = function () {
        var self = this;

        var IsUpdatable = false;

        self.UserId = ko.observable("");
        self.FirstName = ko.observable("");
        self.LastName = ko.observable("");
        self.Position = ko.observable("");
        self.Department = ko.observable("");
        self.DateHired = ko.observable("");

        var EmployeeInfo = {
            UserId: self.UserId,
            FirstName: self.FirstName,
            LastName: self.LastName,
            Position: self.Position,
            Department: self.Department,
            DateHired: self.DateHired
        };

        self.Employees = ko.observable([]);

        self.Message = ko.observable("");

        loadCurrentEmployees();

        function loadCurrentEmployees() {
            $.ajax({
                url: "/api/EmployeeAPI",
                type: "GET"
            }).done(function (resp) {
                self.Staffs(resp);
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }
    };
    ko.applyBindings(new viewModel());
})();
