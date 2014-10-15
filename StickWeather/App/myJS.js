var app = angular.module('myJS', ['ngRoute'])

app.config(function ($routeProvider) {
    $routeProvider.when('/', {templateUrl:'App/Views/HomeView.html'});
});