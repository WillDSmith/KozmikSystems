// Service to get data from the service
ksapp.service('ksservice', function ($http) {
    this.getAllEmployees = function () {
        return $http.get('/api/EmployeeAPI');
    }

    // Save
    this.save = function (Employee) {
        var request = $http({
            method: 'post',
            url: '/api/EmployeeAPI/',
            data: Employee

        });
        return request;
    }

});