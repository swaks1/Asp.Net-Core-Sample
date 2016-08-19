ToDoApp
    .factory('peopleService', ['$http', function ($http) {
        return {
            getPeople: function (callback) {
                $http.get("/api/people")
                    .then(function (response) {
                        callback(response.data);
                    },
                    function (response) {
                        console.log("error in getting people");
                    });
            },            
            getPerson: function (personId,callback) {
                $http.get("/api/people/"+personId)
                    .then(function (response) {
                        callback(response.data);
                    },
                    function (response) {
                        console.log("error in getting person");
                    });
            },
            deletePerson: function (personId,callback) {
                $http.delete("/api/people/"+personId)
                    .then(function (response) {
                        callback(response.data);
                    },
                    function (response) {
                        console.log("error in deleting Person");
                    });
            },
            insertPerson: function (person,callback) {
                $http.post("/api/people", person)
                    .then(function (response) {
                        callback(response.data);
                    },
                    function () {
                        console.log("error in inserting Person");
                    });
            },
            updatePerson: function (person, callback) {
                $http.put("/api/people/"+ person.personId, person)
                    .then(function (response) {
                        callback(response.data);
                    },
                    function () {
                        console.log("error in updating Person");
                    });
            },
            addTaskToPerson: function (personId, task, callback) {              
                $http.post("/api/tasks/"+ personId, task)
                 .then(function (response) {
                     callback(response.data);
                 },
                 function () {
                     console.log("error in adding Task to Person");
                 });
            },
            deleteTask: function (personTaskId, callback) {
                $http.delete("/api/tasks/" + personTaskId)
                .then(function (response) {
                    callback(response.data);
                },
                function (response) {
                    console.log("error in deleting Task");
                });
            }

        }
    }]);