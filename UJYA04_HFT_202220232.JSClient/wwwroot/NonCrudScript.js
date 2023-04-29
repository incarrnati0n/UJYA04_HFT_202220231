let manager;
let managername;
let player;

function getManager() {
    let id = document.getElementById("shnum_input");
    fetch(`http://localhost:24518/stat/ListPlayerByShirtNumber/${id.value}`)
        .then(x => x.json())
        .then(y => {
            manager = y;
            console.log(manager);
            managerDisplay();
        })
}


function getManagerName() {
    let id = document.getElementById("teamid_input");
    fetch(`http://localhost:24518/stat/ManagerName/${id.value}`)
        .then(x => x.json())
        .then(y => {
            managername = y;
            console.log(managername);
            document.getElementById('resultdiv').innerHTML =
                "<label>The manager's name is: " + managername + "</label>";
            document.getElementById('resultdiv').style.display = 'flex';
        })
}

function highestRated() {
    let age = document.getElementById("age_input");
    let teamname = document.getElementById("teamname_input");
    fetch(`http://localhost:24518/stat/HighestRatingByTeamAndAge/${age},${teamname}`)
        .then(x => x.json())
        .then(y => {
            playername = y;
            console.log(playername);
            playerDisplay();
        })
}

function managerDisplay() {
    document.getElementById('resultdiv').innerHTML = "";
    manager.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The queried manager's name: " + t.managerName  + "</td><td>"
            + "</td></tr>";
    });
}

function playerDisplay() {
    document.getElementById('resultdiv').innerHTML = "";
    player.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The queried player's name: " + t.playername + " rating: " +  t.rating + "</td><td>"
            + "</td></tr>";
    });
}