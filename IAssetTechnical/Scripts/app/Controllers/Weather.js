WeatherModule.controller("WeatherController", ['$scope', '$http', 'WeatherService', function ($scope, $http, WeatherService) {
    $scope.Countries = null;
    $scope.Cities = [];
    $scope.show = false;
    $scope.WeatherRequestVModel = { country: '', city: '', usemock : false };
    $scope.WeatherResponseVModel = {};
    WeatherService.getCountries().then(function (data) { $scope.Countries = data.data; });
    $scope.populateCities = function ()
    {
        WeatherService.getCitiesByCountry($scope.WeatherRequestVModel).then(function (data) {
            $scope.Cities = data.data;
        });
    }
    $scope.getWeather = function () {        
        WeatherService.getWeatherForCityAndCountry($scope.WeatherRequestVModel).then(function (data) {
            $scope.WeatherResponseVModel = data.data;
            $scope.show = true;
        });
    }
}]);