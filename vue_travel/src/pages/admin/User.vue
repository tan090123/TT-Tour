<template lang="">
    <div class="tour-table">
        <div class="container-fluid">
            <h2 class="table-h2 text-center">Danh sách người dùng</h2>
            <div class="table-container">
                <table class="table-container" style="width: 100rem;">
                    <thead>
                        <tr>
                            <th style="width: 5px;">ID</th>
                            <th style="width: 5px;">Email</th>
                            <th style="width: 5px;">Họ tên</th>
                            <th style="width: 5px;">Số điện thoại</th>
                            <th style="width: 20px;">Role</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in displayedItems" :key="item.userID">
                            <td>{{ item.userID }}</td>
                            <td>{{ item.email }}</td>
                            <td>{{ item.fullname }}</td>
                            <td>{{ item.phoneNumber }}</td>
                            <td>{{ getRoleTypeName(item.roleID) }}</td>
                            <td style="padding: 0 10px; width: 50px;">
                                <button class="btn btn-success" style="padding: 10px 15px; margin-right: 5px;"
                                    type="button" @click="editItem(item.userID)" data-toggle="tooltip"
                                    data-placement="top" title="Edit">
                                    <i class="fa fa-edit"></i>
                                </button>
                                <button class="btn btn-danger" style="padding: 10px 15px;" type="button"
                                    @click="Confirm('Bạn có chắc chắn muốn xóa không ?') ? deleteItem(item.userID) : '' "
                                    data-toggle="tooltip" data-placement="top" title="Delete">
                                    <i class="fa fa-trash"></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <ThePagination :current-page="currentPage" :total-pages="totalPages" @page-change="changePage"/>
            
        </div>
    </div>
</template>
<script>
import  ThePagination from "@/components/ThePagination.vue";
export default {
    name: 'User-Admin',
    components: {
        ThePagination
    },
    data() {
        return {
            users: [],
            roles: [],
            perPage: 5,
            currentPage: 1,
        }
    },
    computed: {
        totalPages() {
            return Math.ceil(this.users.length / this.perPage);
        },
        displayedItems() {
            const start = (this.currentPage - 1) * this.perPage;
            const end = start + this.perPage;
            return this.users.slice(start, end);
        },
    },
    mounted() {
        this.getUsers();
        this.getRole();
    },
    methods: {
        changePage(page) {
            this.currentPage = page;
        },
        getUsers() {
            // eslint-disable-next-line
            axios.get('/api/User')
                .then((response) => {
                    // handle success
                    this.users = response.data;
                })
                .catch((error) => {
                    // handle error
                    console.log(error);
                });
        },
        deleteItem(itemId) {
            // eslint-disable-next-line
            axios.delete(`/api/User/${itemId}`)
                .then(response => {
                    // Xử lý kết quả thành công
                    console.log(response.data);
                    window.location.href = '/admin/user';
                })
                .catch(error => {
                    // Xử lý lỗi
                    console.error(error);
                });
        },
        getRole() {
            // eslint-disable-next-line
            axios.get('/api/Role')
                .then((response) => {
                    // handle success
                    this.roles = response.data;
                })
                .catch((error) => {
                    // handle error
                    console.log(error);
                });
        },
        // Set name tour type
        getRoleTypeName(roleID) {
            const roleTypes = this.roles.find(roles => roles.roleID === roleID);
            return roleTypes ? roleTypes.roleName : '';
        },
        Confirm(message) {
            return confirm(message);
        },
    },
}
</script>
<style lang="scss" scoped>
.tour-table {
    margin: 3rem;
}

.table-h2 {
    padding: 5rem 0 3rem 0;
    font-size: 3rem;
    font-weight: 600;
}

.create-table {
    color: #ff7675;
    align-items: end;
}

.table-container {
    width: 100%;
    overflow-x: scroll;
}

table {
    width: 100%;
    border-collapse: collapse;
}

th,
td {
    padding: 8px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}

td {
    /* height: 1rem; */
    min-height: 1rem;
    max-height: 1rem;
}

th {
    background-color: #ff7675;
    color: #fff;
    /* width: 50px; */
}

/* .td-desc {
        display: -webkit-box;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 5;
        overflow: hidden;
        text-overflow: 'ellipsis';
    } */

.pagination {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 2rem 0;
}

.page-link {
    padding: 5px 10px;
    background-color: #fff;
    cursor: pointer;
}
</style>