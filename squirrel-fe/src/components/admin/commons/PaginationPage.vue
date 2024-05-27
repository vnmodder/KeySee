<template>
  <slot :config="config" :items="displayedData" :options="options" :startIndex="startIndex" ></slot>
  <nav v-if="visiblePages.length > 1" class="d-flex justify-content-end">
    <ul class="pagination d-flex align-items-center">
      <span class="me-2"
        >Trang <strong>{{ currentPage }}</strong> của
        <strong>{{ totalPages }}</strong> trang</span
      >
      <li class="page-item" v-if="Math.min(...visiblePages) > 1">
        <button class="page-link" @click="gotoPage(1)">
          <span>&laquo;</span>
        </button>
      </li>
      <li class="page-item" v-if="currentPage != 1">
        <button class="page-link" @click="prevPage">
          <span>&lt;</span>
        </button>
      </li>
      <li
        v-for="pageNumber in visiblePages"
        :key="pageNumber"
        class="page-item"
        :class="{ active: pageNumber === currentPage }"
      >
        <button class="page-link" @click="gotoPage(pageNumber)">
          {{ pageNumber }}
        </button>
      </li>
      <li class="page-item" v-if="currentPage < totalPages">
        <button class="page-link" @click="nextPage">
          <span>&gt;</span>
        </button>
      </li>
      <li class="page-item">
        <button
          class="page-link"
          v-if="Math.max(...visiblePages) < totalPages"
          @click="gotoPage(totalPages)"
        >
          <span aria-hidden="true">&raquo;</span>
        </button>
      </li>
    </ul>
  </nav>
</template>

<script setup lang="ts">
import { defineProps, computed, ref, type Ref } from "vue";
import { Table } from ".";
import type { HeaderTable } from "./interface";

interface Props {
  dataItems?: Array<any>;
  pageSize?: number;
  config?: any;
  options?: any
  totalPagesToShow?: number;
}

const props = withDefaults(defineProps<Props>(), {
  dataItems: Array,
  pageSize: 10,
  totalPagesToShow: 5,
  config: Array,
});

const currentPage = ref(1);
const totalPages = computed(() =>
  Math.ceil(props.dataItems?.length / props.pageSize)
);
const displayedData = computed(() =>
  props.dataItems.slice(startIndex.value, startIndex.value + props.pageSize)
);
const startIndex = computed(() => (currentPage.value - 1) * props.pageSize);

const visiblePages = computed(() => {
  const half = Math.floor(props.totalPagesToShow / 2);
  let start = currentPage.value - half;
  if (start < 1) {
    start = 1;
  }
  let end = start + props.totalPagesToShow - 1;
  if (end > totalPages.value) {
    end = totalPages.value;
    start = end - props.totalPagesToShow + 1;
    if (start < 1) {
      start = 1;
    }
  }
  return Array.from({ length: end - start + 1 }, (_, i) => start + i);
});

const gotoPage = (page: number) => {
  if (page >= 1 && page <= totalPages.value) {
    currentPage.value = page;
  }
};

const prevPage = () => {
  gotoPage(currentPage.value - 1);
};

const nextPage = () => {
  gotoPage(currentPage.value + 1);
};
</script>
