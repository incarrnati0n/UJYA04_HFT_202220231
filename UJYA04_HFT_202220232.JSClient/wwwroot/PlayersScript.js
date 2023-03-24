let players = [];
let connection;

let playerIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:24518/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayersCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayersDeleted", (user, message) => {
        getdata();
    });

    connection.on("PlayersUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}




async function getdata() {
    await fetch('http://localhost:24518/Players/')
        .then(x => x.json())
        .then(y => {
            players = y;
            //console.log(players);
            display();
        });
}


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


function display() {
    document.getElementById('databoard').innerHTML = "";
    players.forEach(t => {
        document.getElementById('databoard').innerHTML +=
            "<tr><td>" + t.playerId + "</td><td>"
            + t.playerName + "</td><td>"
            + t.playerShirtNum + "</td><td>"
            + t.rating + "</td><td>"
            + t.playerAge + "</td><td>"
            + `<button type="button" onclick="remove(${t.playerId})"/> Delete`
            + `<button type="button" onclick="showupdate(${t.playerId})"/> Update`
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('playeridupdate').value = players.find(t => t['playerId'] == id)['playerId'];
    document.getElementById('playernameupdate').value = players.find(t => t['playerId'] == id)['playerName'];
    document.getElementById('playershirtnumupdate').value = players.find(t => t['playerId'] == id)['playerShirtNum'];
    document.getElementById('playerratingupdate').value = players.find(t => t['playerId'] == id)['rating'];
    document.getElementById('playerageupdate').value = players.find(t => t['playerId'] == id)['playerAge'];
    document.getElementById('updatediv').style.display = 'flex';
    playerIdToUpdate = id;
}


function update() {
    document.getElementById('updatediv').style.display = 'none';
    let name = document.getElementById('playernameupdate').value;
    let shirtnum = document.getElementById('playershirtnumupdate').value;
    let rating_ = document.getElementById('playerratingupdate').value;
    let age = document.getElementById('playerageupdate').value;
    fetch('http://localhost:24518/Players', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { playerId: playerIdToUpdate, playerName: name, playerShirtNum: shirtnum, rating: rating_, playerAge: age }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:24518/Players/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}


function create() {
    let id = document.getElementById('playerid').value;
    let name = document.getElementById('playername').value;
    let shirtnum = document.getElementById('playershirtnum').value;
    let rating_ = document.getElementById('playerrating').value;
    let age = document.getElementById('playerage').value;
    fetch('http://localhost:24518/Players', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { playerId: id, playerName: name, playerShirtNum: shirtnum, rating: rating_, playerAge: age }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}