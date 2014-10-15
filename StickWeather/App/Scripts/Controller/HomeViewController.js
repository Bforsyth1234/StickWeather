app.controller('HomeController', ['$scope', 'weatherService', function ($scope, weatherService) {
    $scope.findWeather = function (zip) {
        $scope.haveZip = true;

        $scope.place = '';
        console.log(zip);

        console.log($scope.place);
        weatherService.getWeather(zip).then(function (data) {
            console.log(data);
          
            $scope.place = data;
        });
    };
    
}]);
