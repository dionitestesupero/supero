app.factory("TaskResource", ["$resource", function ($resource) {
    return $resource(baseUrl + "api/Task/:action/:id",
        {
            id: '@id',
            action: '@action'
        },
        {
            delete: {
                method: 'POST',
                params: { action: "Delete" },
                isArray: false
            },
            getOpen: {
                method: 'GET',
                params: { action: "getOpen" },
                isArray: true
            },
            getResolved: {
                method: 'GET',
                params: { action: "getResolved" },
                isArray: true
            },
            save: {
                method: 'POST',
                params: { action: "Save" },
                isArray: false
            },
            update: {
                method: 'POST',
                params: { action: "Update" },
                isArray: false
            }
        });
}]);