import pyautogui
import time


class MyService:
  xConfirm = -1200
  yConfirm = -600

  xDeleteButton = -650
  yDeleteButton = -850

  def deleteTasks(self):
    """Delete all tasks in the list."""
    for i in range(1):
      y = self.yDeleteButton
      for j in range(20):
        y += 35
        pyautogui.moveTo(self.xDeleteButton, y, duration=0.05)
        # pyautogui.click(self.xDeleteButton, y)
        pyautogui.moveTo(self.xConfirm, self.yConfirm, duration=0.05)
        # pyautogui.click(self.xConfirm, self.yConfirm)
      time.sleep(2)

if __name__ == '__main__':
  mService = MyService()
  mService.deleteTasks()