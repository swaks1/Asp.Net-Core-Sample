ToDoApp
    .controller('homeController', ['$rootScope', '$scope', 'peopleService',
        function ($rootScope, $scope, $peopleService) {

            $scope.test = "You are in TEST view";
            $scope.person = {};
            $scope.people = [];          
            $scope.addNewBool = false;

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
            $scope.task = {};
            $scope.minDate = new Date();
            $scope.editPhoto = false;
            $scope.editInfo = false;
            $scope.addTaskBool = false;

            $scope.initPerson = function (person) {
                console.log(person,"person added to scope");
                $scope.person = person;
            };

            $scope.updatePerson = function (person) {
                $peopleService.updatePerson(person, function (data) {
                    $scope.person = data;
                    $scope.editInfo = false;
                });
               
            }

            $scope.addTask = function () {
                var personId = $scope.person.personId;
                $scope.task.personId = personId;

                $peopleService.addTaskToPerson(personId, $scope.task, function(data){
                    console.log(data,"recieved task");
                    $scope.person.personTasks.push(data);
                    $scope.task = {};
                });
            }

            $scope.deleteTask = function (personTaskId) {
                $peopleService.deleteTask(personTaskId, function (data) {
                    console.log(data, "deleted task");
                    $peopleService.getPerson($scope.person.personId, function (data) {
                        console.log(data, "got the person");
                        $scope.person = data;
                    });
                });
            };

           

             
        }])

