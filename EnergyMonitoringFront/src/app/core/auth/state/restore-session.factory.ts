import { restoreSession } from './restore-session';

export function restoreSessionFactory() {
  return () => restoreSession();
}