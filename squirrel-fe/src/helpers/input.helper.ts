import type {
  GroupItemConfig,
  ItemConfig,
} from "@/components/admin/commons/interface";
import { ControlStyle, GroupStyle } from "@/enums/admin.enums";
import type { Ref } from "vue";

export const getInputValue = (
  config: Array<GroupItemConfig>,
  key: string,
  groupId: string | number | undefined = undefined
): any => {
  if (groupId) {
    const group = config.find((x) => x.id == groupId);
    if (group && group.groupStyle == GroupStyle.radio) {
      return group.groupValue;
    }
    return group?.groupItem?.find((x) => x.id == key)?.modelValue;
  }
  for (const group of config) {
    const groupItem = group.groupItem?.find((x) => x.id == key);
    if (groupItem) {
      if (groupItem.controlStyle == ControlStyle.radio) {
        return group.groupValue;
      }
      return groupItem.modelValue;
    }
  }
  return undefined;
};

export const setInputValue = (
  config: Ref<Array<GroupItemConfig>>,
  value: any,
  key: string,
  groupId: string | number | undefined = undefined
) => {
  if (groupId) {
    const group = config.value.find((x) => x.id == groupId);
    const item = group?.groupItem?.find((x) => x.id == key);
    if (group && group.groupStyle == GroupStyle.radio) {
      group.groupValue = value;
    }
    if (item) item.modelValue = value;
    return;
  }

  for (const group of config.value) {
    if (group.groupStyle == GroupStyle.radio) {
      group.groupValue = value;
      return;
    }
    const groupItem = group.groupItem?.find((x) => x.id == key);
    if (groupItem) {
      groupItem.modelValue = value;
      return;
    }
  }
};
