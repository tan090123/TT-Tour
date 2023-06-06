<template lang="">
    <div class="tour-table">
        <div class="container-fluid">
            <h2 class="table-h2 text-center">Danh sách Tour</h2>
            <p class="text-end">
                <router-link class="create-table" :to="{ name: 'create-tour' }">
                    Create Tour <i class='bx bxs-file-plus icon'></i>
                </router-link>
            </p>
            <div class="table-container">
                <table class="table-container" style="width: 220rem;">
                    <thead>
                        <tr>
                            <th style="width: 12px;">ID</th>
                            <th style="width: 80px;">Code</th>
                            <th style="width: 180px;">Name</th>
                            <th>Image</th>
                            <th style="width: 30px;">Departure</th>
                            <th>Destination</th>
                            <th style="width: 200px;">Description</th>
                            <th style="width: 30px;">Price</th>
                            <th style="width: 30px;">PromotionPrice</th>
                            <th style="width: 30px;">DiscountTour</th>
                            <th>CheckinDays</th>
                            <th>CheckoutDays</th>
                            <th>TotalSit</th>
                            <th>AvailableSit</th>
                            <th>Type</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in displayedItems" :key="item.id">
                            <td>{{ item.tourID }}</td>
                            <td>{{ item.tourCode }}</td>
                            <td>{{ item.tourName }}</td>
                            <td><img style="width: 120px;" :src="require(`@/../public/images/card/${item.tourImage}`)"
                                    alt="Tour 1"></td>
                            <td>{{ item.departure }}</td>
                            <td>{{ item.destination }}</td>
                            <td class="td-desc">{{ item.description }}</td>
                            <td>{{ formatter.format(item.price)
                                }}</td>
                            <td>{{ formatter.format(item.promotionPrice)
                                }}</td>
                            <td>{{ item.discountTour }}</td>
                            <td>{{ item.tourCheckinDays }}</td>
                            <td>{{ item.tourCheckoutDays }}</td>
                            <td>{{ item.tourTotalSit }}</td>
                            <td>{{ item.tourAvailableSit }}</td>
                            <td>{{ item.tourType }}</td>
                            <td style="padding: 0 10px; width: 100px;">
                                <button class="btn btn-success" style="padding: 10px 15px; margin-right: 5px;"
                                    type="button" data-toggle="tooltip" data-placement="top" title="Edit"><i
                                        class="fa fa-edit"></i></button>
                                <button class="btn btn-danger" style="padding: 10px 15px;" type="button"
                                    @click="Confirm('Bạn có chắc chắn muốn xóa không ?') ? deleteItem(item.tourID) : '' "
                                    data-toggle="tooltip" data-placement="top" title="Delete">
                                    <i class="fa fa-trash"></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- Start Pagination -->
            <section class="pagination">
                <ul class="pagination">
                    <li class="page-item" :class="{ 'disabled': currentPage === 1 }">
                        <a class="page-link visuallyhidden" @click="currentPage--">«</a>
                    </li>
                    <li class="page-item" v-for="pageNumber in totalPages" :key="pageNumber"
                        :class="{ 'active': currentPage === pageNumber }">
                        <a class="page-link visuallyhidden" @click="currentPage = pageNumber">{{ pageNumber }}</a>
                    </li>
                    <li class="page-item" :class="{ 'disabled': currentPage === totalPages }">
                        <a class="page-link visuallyhidden" @click="currentPage++">»</a>
                    </li>
                </ul>
            </section>
            <!-- End Pagination -->
        </div>
    </div>
</template>
<script>
export default {
    name: 'tour-admin',
    data() {
        return {
            perPage: 4,
            currentPage: 1,
            items: [],
            formatter: new Intl.NumberFormat("vi-VN", {
                style: "currency",
                currency: "VND",
            }),
        };
    },
    computed: {
        totalPages() {
            return Math.ceil(this.items.length / this.perPage);
        },
        displayedItems() {
            const start = (this.currentPage - 1) * this.perPage;
            const end = start + this.perPage;
            return this.items.slice(start, end);
        },
    },

    mounted() {
        this.getAllItem();
    },
    methods: {
        getAllItem() {
            // eslint-disable-next-line
            axios.get('/api/Tour')
                .then((response) => {
                    // handle success
                    this.items = response.data;
                })
                .catch((error) => {
                    // handle error
                    console.log(error);
                });
        },

        Confirm(message) {
            return confirm(message);
        },

        deleteItem(itemId) {
            // eslint-disable-next-line
            axios.delete(`/api/Tour/${itemId}`)
                .then(response => {
                    // Xử lý kết quả thành công
                    console.log(response.data);

                    // Sau khi xóa thành công, cập nhật lại danh sách hiển thị
                    this.items = this.items.filter(item => item.tourID !== itemId);
                    // Window.location.reload();
                })
                .catch(error => {
                    // Xử lý lỗi
                    console.error(error);
                });
        },
    }
}

</script>
<style lang="scss" scoped>
.tour-table {
    padding: 0 3rem;
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
    height: 1rem;
    min-height: 1rem;
    max-height: 1rem;
}

th {
    background-color: #ff7675;
    color: #fff;
    width: 100px;
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
