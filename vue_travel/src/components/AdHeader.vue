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
    // Lấy email từ localStorage hoặc sessionStorage
    this.adminEmail = localStorage.getItem('adminEmail');
  },
  methods: {
    logout() {
      // Xóa email từ localStorage hoặc sessionStorage
      localStorage.removeItem('adminEmail');
      // Điều hướng đến trang đăng nhập hoặc trang chủ
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