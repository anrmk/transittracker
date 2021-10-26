class TransitHub {
    constructor(options, callback) {
        this.options = options;
        this.connection = null;
        this.callback = callback;

        this.initialize();
    }

    initialize() {
        this.connection = new signalR.HubConnectionBuilder().withUrl("/transitHub").build();
        this.connection.on("ReceiveMessage", (data) => {
            if (this.callback != null) {
                this.callback(data);
            }
        });

        this.connection.onclose(async () => { setTimeout(() => this.start(), 10000); });

        this.start();
    }

    start() {
        var hub = this;
        try {
            this.connection.start().then((e) => {
                console.log("Hub connected");
                hub.connection.invoke('getConnectionId').then((connectionId) => {
                    sessionStorage.setItem('conectionId', connectionId);// Send the connectionId to controller
                }).catch(err => console.error(err.toString()));
            }).catch(err => {
                setTimeout(() => this.start(), 5000);
                return console.log(err);
            });
        } catch (e) {
            console.log(e);
        }
    }
}