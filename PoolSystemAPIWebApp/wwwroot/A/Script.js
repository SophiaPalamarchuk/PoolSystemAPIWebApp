document.addEventListener('DOMContentLoaded', () => {
    const createScheduleForm = document.getElementById('createScheduleForm');
    const editScheduleForm = document.getElementById('editScheduleForm');
    const schedulesTable = document.getElementById('schedulesTable').querySelector('tbody');
    const editModal = document.getElementById('editModal');

    createScheduleForm.addEventListener('submit', async (event) => {
        event.preventDefault();
        const formData = new FormData(createScheduleForm);
        const data = {
            dayOfWeek: formData.get('dayOfWeek'),
            startTime: formData.get('startTime'),
            endTime: formData.get('endTime')
        };

        const response = await fetch('/api/Schedules', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Schedule created successfully!');
            loadSchedules();
            createScheduleForm.reset();
        } else {
            alert('Failed to create schedule.');
        }
    });

    editScheduleForm.addEventListener('submit', async (event) => {
        event.preventDefault();
        const scheduleId = document.getElementById('editScheduleId').value;
        const formData = new FormData(editScheduleForm);
        const data = {
            scheduleId,
            dayOfWeek: formData.get('dayOfWeek'),
            startTime: formData.get('startTime'),
            endTime: formData.get('endTime')
        };

        const response = await fetch(`/api/Schedules/${scheduleId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Schedule updated successfully!');
            loadSchedules();
            closeModal();
        } else {
            alert('Failed to update schedule.');
        }
    });

    async function loadSchedules() {
        const response = await fetch('/api/Schedules');
        const schedules = await response.json();
        schedulesTable.innerHTML = '';

        schedules.forEach(schedule => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${schedule.scheduleId}</td>
                <td>${schedule.dayOfWeek}</td>
                <td>${schedule.startTime}</td>
                <td>${schedule.endTime}</td>
                <td>
                    <button onclick="openEditModal(${schedule.scheduleId}, '${schedule.dayOfWeek}', '${schedule.startTime}', '${schedule.endTime}')">Edit</button>
                    <button onclick="deleteSchedule(${schedule.scheduleId})">Delete</button>
                </td>
            `;
            schedulesTable.appendChild(row);
        });
    }

    loadSchedules();
});

function openEditModal(id, dayOfWeek, startTime, endTime) {
    document.getElementById('editScheduleId').value = id;
    document.getElementById('editDayOfWeek').value = dayOfWeek;
    document.getElementById('editStartTime').value = startTime;
    document.getElementById('editEndTime').value = endTime;
    document.getElementById('editModal').style.display = "block";
}

function closeModal() {
    document.getElementById('editModal').style.display = "none";
}

async function deleteSchedule(id) {
    const response = await fetch(`/api/Schedules/${id}`, {
        method: 'DELETE'
    });

    if (response.ok) {
        alert('Schedule deleted successfully!');
        loadSchedules();
    } else {
        alert('Failed to delete schedule.');
    }
}
