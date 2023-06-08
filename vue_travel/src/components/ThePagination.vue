<template>
    <div>
        <ul class="pagination">
            <li :class="{ disabled: currentPage === 1 }">
                <a @click="goToPage(currentPage - 1)" href="#">«</a>
            </li>
            <li v-for="pageNumber in totalPages" :key="pageNumber" :class="{ active: currentPage === pageNumber }">
                <a @click="goToPage(pageNumber)" href="#">{{ pageNumber }}</a>
            </li>
            <li :class="{ disabled: currentPage === totalPages }">
                <a @click="goToPage(currentPage + 1)" href="#">»</a>
            </li>
        </ul>
    </div>
</template>

<script>
    export default {
        name: 'Pagination-component',
        props: {
            currentPage: {
                type: Number,
                required: true
            },
            totalPages: {
                type: Number,
                required: true
            }
        },
        methods: {
            goToPage(page) {
                if (page >= 1 && page <= this.totalPages) {
                    this.$emit('page-change', page);
                }
            }
        }
    };
</script>

<style scoped>
    .pagination {
        display: flex;
        justify-content: center;
        align-items: center;
        margin: 3rem 0;
        list-style: none;
        padding: 0;
    }

    .pagination li {
        margin-right: 5px;
    }

    .pagination li a {
        text-decoration: none;
        color: #333;
        padding: 5px 10px;
        border: 1px solid #ccc;
    }

    .pagination li.disabled a {
        pointer-events: none;
        color: #999;
    }

    .pagination li.active a {
        background-color: #333;
        color: #fff;
    }

</style>
