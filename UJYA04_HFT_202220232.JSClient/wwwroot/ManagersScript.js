let managers = [];
let connection;

let managerIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:24518/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ManagersCreated", (user, message) => {
        getdata();
    });

    connection.on("ManagersDeleted", (user, message) => {
        getdata();
    });

    connection.on("ManagersUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}




async function getdata() {
    await fetch('http://localhost:24518/Managers/')
        .then(x => x.json())
        .then(y => {
            managers = y;
            //console.log(teams);
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
    managers.forEach(t => {
        document.getElementById('databoard').innerHTML +=
            "<tr><td>" + t.managerId + "</td><td>"
            + t.managerName + "</td><td>"
            + t.managerAge+ "</td><td>"
            + t.managerSalary + "</td><td>"
            + `<button type="button" onclick="remove(${t.managerId})"/> Delete`
            + `<button type="button" onclick="showupdate(${t.managerId})"/> Update`
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('manageridupdate').value = managers.find(t => t['managerId'] == id)['managerId'];
    document.getElementById('managernameupdate').value = managers.find(t => t['managerId'] == id)['managerName'];
    document.getElementById('managerageupdate').value = managers.find(t => t['managerId'] == id)['managerAge'];
    document.getElementById('managersalaryupdate').value = managers.find(t => t['managerId'] == id)['managerSalary'];
    document.getElementById('updatediv').style.display = 'flex';
    managerIdToUpdate = id;
}


function update() {
    document.getElementById('updatediv').style.display = 'none';
    let name = document.getElementById('managernameupdate').value;
    let age = document.getElementById('managerageupdate').value;
    let salary = document.getElementById('managersalaryupdate').value;
    fetch('http://localhost:24518/Managers', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { managerId: managerIdToUpdate, managerName: name, managerAge: age, managerSalary: salary }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:24518/Managers/' + id, {
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
    let id = document.getElementById('managerid').value;
    let name = document.getElementById('managernameupdate').value;
    let age = document.getElementById('managerageupdate').value;
    let salary = document.getElementById('managersalaryupdate').value;
    fetch('http://localhost:24518/Managers', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { managerId: id, managerName: name, managerAge: age, managerSalary: salary }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}