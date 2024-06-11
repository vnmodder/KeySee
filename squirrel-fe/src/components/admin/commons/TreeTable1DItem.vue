<template>
  <template v-for="(node, index) in nodes" :key="node.id">
    <tr>
      <td
        v-if="config?.options?.showCheck"
        :style="'text-align: center'"
        class="align-middle"
      >
        <input
          type="checkbox"
          v-model="node[config?.options?.checkMember ?? 'checkMember']"
          @change="
            (e) =>
              checkChanged(
                e,
                node,
                config?.options?.checkMember ?? 'checkMember'
              )
          "
        />
      </td>
      <td class="align-middle">
        <span :style="'margin-left:' + depth + 'rem'">
          <span
            v-if="node.children && node.children.length != 0"
            @click="toggleNode(node, index)"
          >
            <i
              v-if="expandedNodes[nodeIndex(node, index)]"
              class="fas fa-caret-down"
            ></i>
            <i v-else class="fas fa-caret-right"></i>
          </span>
          <span
            :style="
              !node.children || node.children.length < 1
                ? 'margin-left:0.60rem'
                : ''
            "
          >
            {{ node.name }}
          </span>
        </span>
      </td>
      <template
        v-for="col in config?.headers.filter((x) => x.id != 'name')"
        :key="col.id"
      >
        <td class="align-middle" :class="[col.className]">
          <a v-if="col.columnStyle == ColumnStyle.link" :href="node[col.id]">
            {{ node[col.id] }}</a
          >
          <span v-else-if="col.columnStyle == ColumnStyle.checkbox">
            <input type="checkbox" v-model="node[col.id]" />
          </span>
          <span v-else>
            {{ node[col.id] }}
          </span>
        </td>
      </template>
      <td
        v-if="
          config?.options?.showDel ||
          config?.options?.showEdit ||
          config?.options?.showDetail
        "
        :style="'text-align: center; cursor: pointer'"
        class="align-middle"
      >
        <i
          v-if="config.options?.showDetail"
          class="fas fa-eye primary-text"
          @click="detailClick(node)"
        ></i>
        <i
          v-if="config.options?.showEdit"
          class="fas fa-pen ms-2"
          @click="editClick(node)"
        ></i>
        <i
          v-if="config.options?.showDel"
          class="fas fa-trash ms-2 text-danger"
          @click="delClick(node)"
        ></i>
      </td>
    </tr>
    <TreeTable1DItem
      v-if="expandedNodes[nodeIndex(node, index)]"
      :nodes="node.children"
      :config="config"
      :depth="depth + 1"
      :parent-index="nodeIndex(node, index)"
    />
  </template>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { TableConfig } from "./interface";
import { ColumnStyle } from "@/enums/admin.enums";

interface Node {
  id: number;
  parent: number;
  children?: Node[];
  [key: string]: any;
}

interface Props {
  config?: TableConfig;
  nodes?: Node[];
  depth: number;
  parentIndex?: string;
}

const props = defineProps<Props>();
const expandedNodes = ref<{ [key: string]: boolean }>({});

const detailClick = (row: Node) => {
  if (props.config?.options?.detailClick) {
    props.config.options?.detailClick(row);
  }
};

const checkChanged = (event: Event, node: Node, key: string) => {
  if (event.target instanceof HTMLInputElement) {
    const check = event.target.checked;
    nodeCheck(check, key, node);
  }
};

const nodeCheck = (check: boolean, key: string, node: Node) => {
  node[key] = check;
  if (node.children && node.children.length > 0) {
    node.children.forEach((child: Node) => {
      nodeCheck(check, key, child);
    });
  }
};

const delClick = (row: Node) => {
  if (props.config?.options?.delClick) props.config.options?.delClick(row);
};

const editClick = (row: Node) => {
  if (props.config?.options?.editClick) props.config.options?.editClick(row);
};

const toggleNode = (node: Node, index: number) => {
  const nodeKey = nodeIndex(node, index);
  expandedNodes.value[nodeKey] = !expandedNodes.value[nodeKey];
};

const nodeIndex = (node: Node, index: number) => {
  return props.parentIndex ? `${props.parentIndex}-${index}` : `${index}`;
};
</script>

<style scoped>
.fas {
  cursor: pointer;
}
</style>
