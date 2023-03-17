let teams = [];

getdata();

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
            + t.teamOwner + "</td><td>" + `<button type="button" onclick="remove(${t.teamId})"/> Delete` + "</td></tr>";
    });
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