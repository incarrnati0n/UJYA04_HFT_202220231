let teams = [];
let connection;

let teamIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:24518/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamsCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamsDeleted", (user, message) => {
        getdata();
    });

    connection.on("TeamsUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
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

async function getdata() {
    await fetch('http://localhost:24518/Teams/')
          .then(x => x.json())
          .then(y => {
            teams = y;
            //console.log(teams);
            display();
          });
}





function display() {
    document.getElementById('databoard').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('databoard').innerHTML +=
            "<tr><td>" + t.teamId + "</td><td>"
            + t.teamName + "</td><td>"
            + t.teamFoundedYear + "</td><td>"
            + t.teamStadiumName + "</td><td>"
            + t.teamOwner + "</td><td>"
            + `<button type="button" onclick="remove(${t.teamId})"/> Delete` 
            + `<button type="button" onclick="showupdate(${t.teamId})"/> Update` 
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('teamidupdate').value = teams.find(t => t['teamId'] == id)['teamId'];
    document.getElementById('teamnameupdate').value = teams.find(t => t['teamId'] == id)['teamName'];
    document.getElementById('teamfoundedyearupdate').value = teams.find(t => t['teamId'] == id)['teamFoundedYear'];
    document.getElementById('teamstadiumnameupdate').value = teams.find(t => t['teamId'] == id)['teamStadiumName'];
    document.getElementById('teamownerupdate').value = teams.find(t => t['teamId'] == id)['teamOwner'];
    document.getElementById('updatediv').style.display = 'flex';
    teamIdToUpdate = id;
}


function update() {
    document.getElementById('updatediv').style.display = 'none';
    let name = document.getElementById('teamnameupdate').value;
    let year = document.getElementById('teamfoundedyearupdate').value;
    let stadium = document.getElementById('teamstadiumnameupdate').value;
    let owner = document.getElementById('teamownerupdate').value;
    fetch('http://localhost:24518/Teams', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { teamId: teamIdToUpdate, teamName: name, teamFoundedYear: year, teamStadiumName: stadium, teamOwner: owner }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:24518/Teams/' + id, {
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
    let id = document.getElementById('teamid').value;
    let name = document.getElementById('teamname').value;
    let year = document.getElementById('teamfoundedyear').value;
    let stadium = document.getElementById('teamstadiumname').value;
    let owner = document.getElementById('teamowner').value;
    fetch('http://localhost:24518/Teams', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { teamId: id, teamName: name, teamFoundedYear: year, teamStadiumName: stadium, teamOwner: owner}),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}