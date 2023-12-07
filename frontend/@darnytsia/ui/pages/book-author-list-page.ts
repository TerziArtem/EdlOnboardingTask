import { createCompareFilter,
  createFilterGroup,
  FreedomUIFilterGroup,
  FreedomUIHandler } from '@edenlabllc/sdk/ui/freedom-ui';
import { useInit, useState } from '@edenlabllc/sdk/hooks';
import { ComparisonType, DataValueType } from '@creatio-devkit/common';
import { constants } from '../../db/consts';

export const EdlBookAuthorsList_Page = (): Array<FreedomUIHandler> => {
  const [, setBookAuthorFilters] =
    useState<FreedomUIFilterGroup>('LookupAttribute_dg5c5vy_List_BusinessRule_Filter');

  useInit(async() => {
    await setupBookAuthorsFilters();
  });

  const setupBookAuthorsFilters = async(): Promise<void> => {
    const filters = createFilterGroup({
      BookAuthorsTypeFilter: createCompareFilter(
        ComparisonType.Equal, 'Type', constants.CONTACT.TYPE.EMPLOYEE, DataValueType.Lookup
      )
    });

    await setBookAuthorFilters(filters);
  };

  return [];
};
