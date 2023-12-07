import {
  createFilterGroup,
  createInFilter,
  DataGridCreateItemRequest,
  FreedomUIHandler,
  LoadDataRequest
} from '@edenlabllc/sdk/ui/freedom-ui';
import { DataValueType, LookupValue } from '@creatio-devkit/common';
import { useEffect, useInit, useState } from '@edenlabllc/sdk/hooks';
import { CURRENT_USER } from '@edenlabllc/sdk/users';
import { constants } from '../../db/consts';

export const EdlBook_FormPage = (): Array<FreedomUIHandler> => {
  const BOOK_STATUS_INPUT = 'LookupAttribute_18u2rk2';
  const [status] = useState<LookupValue>(BOOK_STATUS_INPUT);
  const [, setIsBookNameReadOnly] = useState<boolean>('IsBookNameReadOnly');
  const [authorsList] = useState<any>('GridDetail_groiew2');

  useInit((): void => {
    setBookNameReadOnly();
  });

  useEffect(async(): Promise<void> => {
    await setBookNameReadOnly();
  });

  const setBookNameReadOnly = (): void => {
    if (status()?.value === constants.BOOK.STATUS.PLANNED ||
        CURRENT_USER.roles.includes(constants.SYS_ADMIN_UNIT.SYSTEM_ADMINISTRATORS)) {
      setIsBookNameReadOnly(false);
    } else {
      setIsBookNameReadOnly(true);
    }
  };

  const loadAuthors = (): void => {
    const listData = authorsList();
    listData?.forEach(data => {
      data.GridDetail_groiew2DS_EdlBookAuthor_List_BusinessRule_Filter = createFilterGroup({
        AuthorsFilter: createInFilter(
          'Type',
          DataValueType.Lookup,
          [constants.CONTACT.TYPE.EMPLOYEE])
      });
      data.formApiModel.controls.GridDetail_groiew2DS_EdlBookAuthor_List_BusinessRule_Filter.disable();
    });
  };

  return [
    {
      request: 'crt.LoadDataRequest',
      handler: (request: LoadDataRequest, next): any => {
        if (request.dataSourceName === 'GridDetail_groiew2DS') {
          loadAuthors();
        }
        return next?.handle(request);
      }
    },
    {
      request: 'crt.DataGridCreateItemRequest',
      handler: async(request: DataGridCreateItemRequest, next): Promise<unknown> => {
        const result = await next?.handle(request);

        if (request.dataGridName === 'GridDetail_groiew2') {
          loadAuthors();
        }
        return result;
      }
    }
  ];
};
