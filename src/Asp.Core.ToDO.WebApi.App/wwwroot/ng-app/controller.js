ToDoApp
    .controller('homeController', ['$rootScope', '$scope', 'peopleService',
        function ($rootScope, $scope, $peopleService) {

            $scope.test = "You are in TEST view";

            $scope.person = {};
            $scope.people = [];

            $scope.testData = "DA";

            $peopleService.getPeople(function (data) {
                console.log(data,"success in getting people");
                $scope.people = data;
            });

            $scope.deletePerson = function () {
                var person = $scope.delPerson;
                $peopleService.deletePerson(person.personId, function (data) {
                    console.log(data, "success in deleting person");
                    var index = $scope.people.indexOf(person);
                    $scope.people.splice(index, 1);
                    $("#myModal").modal('hide');
                });
            }

            $scope.savePerson = function(person){
                $peopleService.insertPerson(person, function (data) {
                    console.log(data, "success in saving person");
                    $scope.people.push(data);
                    $scope.person = {};
                });
            }

            $scope.toogleModal = function (boolean,person) {
                if (boolean) {
                    $scope.delPerson = person;                 
                    $("#myModal").modal('show');
                }
                else{
                    $("#myModal").modal('hide');  
                }              
            }
            
        }]).controller('personInfoController', ['$rootScope', '$scope', 'peopleService',
        function ($rootScope, $scope, $peopleService) {       
            $scope.person = {};
            $scope.editPhoto = false;
            $scope.editInfo = false;

            $scope.initPerson = function (person) {
                console.log(person);
                $scope.person = person;
            };

            $scope.updatePerson = function (person) {
                $peopleService.updatePerson(person, function (data) {
                    $scope.person = data;
                    $scope.editInfo = false;
                });
               
            }

           

             
        }])

