var app = angular.module('myApp', []);
let serviceURL = "http://localhost:8080/api/";
app.controller('sessionCtrl', function($scope, $http) {

    $scope.sessionToCreate = {
        "title" : null,
        "speaker" : null 
    }

    $scope.sessionToDelete = {
        "sessionId" : null
    }

    $scope.loadSessions = function(){

        $http.get(serviceURL + "sessions")
            .then(function(response) {
                $scope.sessions = response.data.recordset;
            })
            .catch(function(error){
                $scope.errors = error.data;
            }
        );                        
    }   

    $scope.loadSpeakers = function(){
        $http.get(serviceURL + "speakers")
        .then(function(response) {
            $scope.speakers = response.data.recordset;
        })
        .catch(function(error){
            $scope.errors = error.data;
        }
    ); 
    }

    $scope.createSession = function(){
        $http.post(serviceURL + "sessions", $scope.sessionToCreate )
            .then(function(response) {
                $scope.loadSessions()
            })
            .catch(function(error){
                console.log(error);
            }
        ); 
    }

    $scope.deleteSession = function (){
        $http.delete(serviceURL + "/sessions/" + $scope.sessionToDelete.sessionId)
        .then(function(){
            $scope.loadSessions();
        })
        .catch(function(error){
            console.log(error);
        });
    }

    $scope.loadRatings = function(){
        $http.get(serviceURL + "/ratings")
        .then(function(response) {
            $scope.ratings = response.data.recordset;
        })
        .catch(function(error){
            $scope.errors = error.data;
        });
    }

    $scope.loadRatingsWithId = function(sessionId){
        $http.get(serviceURL + "sessions/" + sessionId + "/ratings")
        .then(function(response) {
            $scope.ratings = response.data.recordset;
        })
        .catch(function(error){
            $scope.errors = error.data;
        });
    }

    $scope.updateRatings = function(){
        if($scope.selectedItem == undefined){
            $scope.loadRatings();
        }else{
            $scope.loadRatingsWithId($scope.selectedItem.SessionId);
        }
    }

    window.onload = function(){
        $scope.loadSpeakers();
    }

});     