<template>
  <table v-if="config && config?.headers?.length" class="table bg-white rounded shadow-sm table-hover">
    <thead>
      <tr class="primary-bg text-white">
        <th class="text-center align-middle" v-if="config?.options?.showCheck">
          <input type="checkbox" @change="(e) =>
              checkChanged(
                e,
                config?.options?.checkMember ?? 'checkMember',
                treeData
              )
            " />
        </th>
        <th class="text-center align-middle">
          {{ config?.headers.find((x) => x.id == "name")?.name }}
        </th>
        <template v-for="h in config?.headers.filter((x) => x.id != 'name')" :key="h.name">
          <th class="text-center align-middle">{{ h.name }}</th>
        </template>
        <th class="text-center align-middle" v-if="
          config?.options?.showDel ||
          config?.options?.showEdit ||
          config?.options?.showDetail
        ">
          Tùy chỉnh
        </th>
      </tr>
    </thead>
    <tbody>
      <TreeTableItem :nodes="treeData" :depth="0" :config="config" />
    </tbody>
  </table>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { TreeTableItem } from ".";
import type { TableConfig } from "./interface";

interface Node {
  id: number;
  parent: number;
  children?: Node[];
  [key: string]: any;
}

interface Props {
  config?: TableConfig;
  nodes?: Node[];
}
const props = defineProps<Props>();

const buildTree = (data: Node[]): Node[] => {
  const map = new Map<number, Node>();
  const roots: Node[] = [];

  data.forEach((item) => {
    item.children = [];
    map.set(item.id, item);
  });

  data.forEach((item) => {
    if (item.parent === 0) {
      roots.push(item);
    } else {
      const parent = map.get(item.parent);
      if (parent) {
        parent.children?.push(item);
      }
    }
  });

  return roots;
};

const treeData = ref(buildTree(props.nodes || []));

const checkChanged = (event: Event, key: string, nodes?: Node[]) => {
  if (event.target instanceof HTMLInputElement) {
    const check = event.target.checked;
    nodeCheck(check, key, nodes);
  }
};

const nodeCheck = (check: boolean, key: string, nodes?: Node[]) => {
  nodes?.forEach((element: Node) => {
    element[key] = check;
    if (element.children && element.children.length > 0) {
      nodeCheck(check, key, element.children);
    }
  });
};
</script>
