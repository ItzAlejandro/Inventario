export function extractErrors(obj: any): string[] {
  const err = obj.error.data;
  let errorMessage: string[] = [];

  if (Array.isArray(err)) {
    errorMessage = err.map((e: any) => `${e.propertyName}: ${e.errorMessage}`);
  }

  return errorMessage;
}
