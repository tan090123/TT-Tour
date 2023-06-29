<template>
    <!-- NAVBAR -->
    <nav>
        <i class='bx bx-menu toggle-sidebar'></i>
        <form action="#">
            <div class="form-group">
                <input type="text" placeholder="Search...">
                <i class='bx bx-search icon'></i>
            </div>
        </form>
        <a href="#" class="nav-link">
            <i class='bx bxs-bell icon'></i>
            <span class="badge">5</span>
        </a>
        <a href="#" class="nav-link">
            <i class='bx bxs-message-square-dots icon'></i>
            <span class="badge">8</span>
        </a>
        <span class="divider"></span>
        <div class="profile">
            <img src="https://images.unsplash.com/photo-1517841905240-472988babdf9?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8cGVvcGxlfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"
                alt="">
            <ul class="profile-link">
                <li><a href="#" v-if="adminEmail">
                        <span>Xin chào admin: </span>
                        <span class="fw-bold">{{ adminEmail }}</span></a></li>
                <li><a href="#"><i class='bx bxs-user-circle icon'></i> Profile</a></li>
                <li><a href="#"><i class='bx bxs-cog'></i> Settings</a></li>
                <li><a href="#" @click="logout"><i class='bx bxs-log-out-circle'></i>Logout</a></li>
            </ul>
        </div>
    </nav>
    <!-- NAVBAR -->
</template>
<script>
export default {
    data() {
        return {
            adminEmail: '',
        }
    },
    mounted() {
        // Lấy email từ localStorage
        this.adminEmail = localStorage.getItem('adminEmail');
        // SIDEBAR DROPDOWN
        const allDropdown = document.querySelectorAll('#sidebar .side-dropdown');
        const sidebar = document.getElementById('sidebar');

        allDropdown.forEach(item => {
            const a = item.parentElement.querySelector('a:first-child');
            a.addEventListener('click', function (e) {
                e.preventDefault();

                if (!this.classList.contains('active')) {
                    allDropdown.forEach(i => {
                        const aLink = i.parentElement.querySelector('a:first-child');

                        aLink.classList.remove('active');
                        i.classList.remove('show');
                    })
                }

                this.classList.toggle('active');
                item.classList.toggle('show');
            })
        })





        // SIDEBAR COLLAPSE
        const toggleSidebar = document.querySelector('nav .toggle-sidebar');
        const allSideDivider = document.querySelectorAll('#sidebar .divider');

        if (sidebar.classList.contains('hide')) {
            allSideDivider.forEach(item => {
                item.textContent = '-'
            })
            allDropdown.forEach(item => {
                const a = item.parentElement.querySelector('a:first-child');
                a.classList.remove('active');
                item.classList.remove('show');
            })
        } else {
            allSideDivider.forEach(item => {
                item.textContent = item.dataset.text;
            })
        }

        toggleSidebar.addEventListener('click', function () {
            sidebar.classList.toggle('hide');

            if (sidebar.classList.contains('hide')) {
                allSideDivider.forEach(item => {
                    item.textContent = '-'
                })

                allDropdown.forEach(item => {
                    const a = item.parentElement.querySelector('a:first-child');
                    a.classList.remove('active');
                    item.classList.remove('show');
                })
            } else {
                allSideDivider.forEach(item => {
                    item.textContent = item.dataset.text;
                })
            }
        })




        sidebar.addEventListener('mouseleave', function () {
            if (this.classList.contains('hide')) {
                allDropdown.forEach(item => {
                    const a = item.parentElement.querySelector('a:first-child');
                    a.classList.remove('active');
                    item.classList.remove('show');
                })
                allSideDivider.forEach(item => {
                    item.textContent = '-'
                })
            }
        })



        sidebar.addEventListener('mouseenter', function () {
            if (this.classList.contains('hide')) {
                allDropdown.forEach(item => {
                    const a = item.parentElement.querySelector('a:first-child');
                    a.classList.remove('active');
                    item.classList.remove('show');
                })
                allSideDivider.forEach(item => {
                    item.textContent = item.dataset.text;
                })
            }
        })




        // PROFILE DROPDOWN
        const profile = document.querySelector('nav .profile');
        const imgProfile = profile.querySelector('img');
        const dropdownProfile = profile.querySelector('.profile-link');

        imgProfile.addEventListener('click', function () {
            dropdownProfile.classList.toggle('show');
        })




        // MENU
        const allMenu = document.querySelectorAll('main .content-data .head .menu');

        allMenu.forEach(item => {
            const icon = item.querySelector('.icon');
            const menuLink = item.querySelector('.menu-link');

            icon.addEventListener('click', function () {
                menuLink.classList.toggle('show');
            })
        })



        window.addEventListener('click', function (e) {
            if (e.target !== imgProfile) {
                if (e.target !== dropdownProfile) {
                    if (dropdownProfile.classList.contains('show')) {
                        dropdownProfile.classList.remove('show');
                    }
                }
            }

            allMenu.forEach(item => {
                const icon = item.querySelector('.icon');
                const menuLink = item.querySelector('.menu-link');

                if (e.target !== icon) {
                    if (e.target !== menuLink) {
                        if (menuLink.classList.contains('show')) {
                            menuLink.classList.remove('show')
                        }
                    }
                }
            })
        })





        // PROGRESSBAR
        const allProgress = document.querySelectorAll('main .card .progress');

        allProgress.forEach(item => {
            item.style.setProperty('--value', item.dataset.value)
        })
    },
    methods: {
        logout() {
            // Xóa email từ localStorage
            localStorage.removeItem('adminEmail');
            window.location.href = '/login';
        }
    }
}
</script>
<style lang="scss" scoped>
header {
    padding: 1.5rem;
    background-color: #6c5ce7;
}

.row {
    --bs-gutter-x: 0 !important;
}

.logo {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    color: #fff;

    img {
        width: 4rem;
        object-fit: cover;
        margin-right: 1.5rem;
    }
}

.text {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    text-align: end;
    padding-right: 1.5rem;
    color: #fff;
}
</style>